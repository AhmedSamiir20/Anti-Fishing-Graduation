

using AntiFishing.Api.Middlewares;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using System.Threading.RateLimiting;




var builder = WebApplication.CreateBuilder(args);


#region Serilog
//read the file we will take the data from it "appsettings.json"

var config = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.Build();

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(config)
	.CreateLogger();

// Replace the default logger with Serilog
builder.Host.UseSerilog();
#endregion

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

#region Dependency Injections
builder.Services.AddInfrastructureDependencies().AddServicesDependencies().AddCoreDependencies();
#endregion

builder.Services.AddHttpClient();

#region Connection to database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
#endregion

#region Hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
builder.Services.AddHangfireServer();
#endregion



#region JWT
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


#endregion
#region Mapping
builder.Services.AddAutoMapper((Assembly.GetExecutingAssembly()));
#endregion



#region SignalR
builder.Services.AddSignalR();

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
#region JWT Bearer
builder.Services.AddSwaggerGen(c =>
{
	//c.OperationFilter<FormFileOperationFilter>();
	c.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "Anti/Fishing Api",
		Version = "v1",
		Description = "Anti/Fishing Api",
		Contact = new OpenApiContact
		{
			Name = "Ahmed Samir",
			Email = "ahmedsamiirr20@gmail.com"
		}
	});
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Enter Your JWT Key",
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement {
		{
			new OpenApiSecurityScheme {
				Reference = new OpenApiReference {
					Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
				},
				Name="Bearer",
				 In = ParameterLocation.Header,
			},
			new List<string>()
		}
	});
	//c.OperationFilter<FileUploadOperation>();
	//c.EnableAnnotations();
});

builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(o =>
	{
		o.RequireHttpsMetadata = false;
		o.SaveToken = false;
		o.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidIssuer = builder.Configuration["JWT:Issuer"],
			ValidAudience = builder.Configuration["JWT:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

		};
	});
#endregion
#region add cors
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", builder =>
	{
		builder.AllowAnyOrigin()
			   .AllowAnyMethod()
			   .AllowAnyHeader();
	});
});
#endregion

#region Add ResponseCompression
builder.Services.AddResponseCompression(options =>
{
	options.EnableForHttps = true; // Enable compression for HTTPS responses
	options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
});
#endregion



#region add rate limiting
builder.Services.AddRateLimiter(options =>
{
	options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
	{
		// Use client IP as key for rate limiting
		return RateLimitPartition.GetFixedWindowLimiter(
			partitionKey: context.Connection.RemoteIpAddress?.ToString() ?? "anonymous",
			factory: _ => new FixedWindowRateLimiterOptions
			{
				PermitLimit = 3,    // Number of allowed requests
				Window = TimeSpan.FromDays(1),  // After how much can user make another 10 requests
				QueueLimit = 0,      // Requests to queue if limit is reached
				AutoReplenishment = true
			});
	});
});

#endregion

var app = builder.Build();



//Security Header
app.Use(async (context, next) =>
{
	// Set security headers
	context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
	context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
	context.Response.Headers.Add("X-Frame-Options", "DENY");
	context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
	context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
	context.Response.Headers.Add("Referrer-Policy", "no-referrer");


	context.Response.Headers.Remove("X-Powered-By");
	context.Response.Headers.Remove("Server");

	await next();
});




// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chathub");
app.UseHttpsRedirection();
app.UseResponseCompression(); // Enable response compression middleware
app.UseMiddleware<ThrottlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseRateLimiter();
app.UseRouting();
app.UseCors("AllowAllOrigins"); // Use the CORS policy named "AllowLocalhost3000"
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/dashboard");
app.MapControllers();
app.Run();