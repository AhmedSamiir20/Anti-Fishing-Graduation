using AntiFishing.Data.Entities.Identity;
using AntiFishing.Data.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AntiFishing.Infrastructure.Repositories
{
	public class AuthRepository : IAuthRepository
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly JWT _jwt;
		private readonly ApplicationDbContext _context;

		public AuthRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, ApplicationDbContext context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_jwt = jwt.Value;
			_context = context;
		}

		public async Task<AuthModel> RegisterAsync(RegisterModel model)
		{
			if (await _userManager.FindByEmailAsync(model.Email) != null)
				return new AuthModel { Message = "Email is already registered" };

			if (await _userManager.FindByNameAsync(model.Username) is not null)
				return new AuthModel { Message = "Username is already registered" };

			var user = new User
			{
				UserName = model.Username,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Country = model.Country,
				Address = model.Address,
				PhoneNumber = model.PhoneNumber,

			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				var errors = string.Empty;
				foreach (var error in result.Errors)
				{
					errors += $"{error.Description},";
				}
				return new AuthModel { Message = errors };
			}

			await _userManager.AddToRoleAsync(user, "User");

			var jwtSecurityToken = await CreateJwtToken(user);

			return new AuthModel
			{
				Email = user.Email,
				ExpiresOn = jwtSecurityToken.ValidTo,
				IsAuthenticated = true,
				Roles = new List<string> { "User" },
				Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
				UserName = user.UserName,
				LakeName = user.Lake.Name

			};
		}
		public async Task<AuthModel> GetTokenAsync(TokenRequestModel model)
		{
			var authModel = new AuthModel();

			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
			{
				authModel.Message = "Email or Password is incorrect";
				return authModel;
			}

			var jwtSecurityToken = await CreateJwtToken(user);
			var rolesList = await _userManager.GetRolesAsync(user);

			authModel.IsAuthenticated = true;
			authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			authModel.UserName = user.UserName;
			authModel.FirstName = user.FirstName;
			authModel.LastName = user.LastName;
			authModel.Address = user.Address;
			authModel.Email = user.Email;
			authModel.PhoneNumber = user.PhoneNumber;
			authModel.ExpiresOn = jwtSecurityToken.ValidTo;
			authModel.Roles = rolesList.ToList();

			return authModel;
		}


		public async Task<JwtSecurityToken> CreateJwtToken(User user)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var roles = await _userManager.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id)
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwt.Issuer,
				audience: _jwt.Audience,
				claims: claims,
				expires: DateTime.Now.AddDays(_jwt.DurationInDays),
				signingCredentials: signingCredentials);

			return jwtSecurityToken;
		}

		public async Task<string> AddRoleAsync(AddRoleModel model)
		{
			var user = await _userManager.FindByIdAsync(model.UserId);
			if (user == null || !await _roleManager.RoleExistsAsync(model.Role))
				return "Invalid User ID Or Role";

			if (await _userManager.IsInRoleAsync(user, model.Role))
				return "User already assigned to this Role";

			var result = await _userManager.AddToRoleAsync(user, model.Role);

			return result.Succeeded ? String.Empty : "Something Went Worng ";
		}

		public async Task<IReadOnlyList<User>> GetUsers()
		{
			var users = await _userManager.Users.ToListAsync();
			return users;
		}

		public async Task<User> GetUser(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			return user;
		}

		public async Task<string> DeleteUser(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user is null)
				return "There is no user by this id";

			// Load user roles
			var userRoles = _context.UserRoles.Where(ur => ur.UserId == id).ToList();

			// Remove user roles
			_context.UserRoles.RemoveRange(userRoles);

			// Remove user
			_context.Users.Remove(user);

			// Save changes
			await _context.SaveChangesAsync();

			return "Deleted Successfully";
		}
	}



}

