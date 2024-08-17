

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();
app.MapHub<ChatHub>("/chathub");
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAllOrigins"); // Use the CORS policy named "AllowLocalhost3000"
app.UseAuthentication();
app.UseAuthorization();
app.UseHangfireDashboard("/dashboard");
app.MapControllers();
app.Run();