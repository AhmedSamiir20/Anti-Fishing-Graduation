using AntiFishing.Data.Entities.Identity;

namespace AntiFishing.Infrastructure.Abstracts
{
	public interface IAuthRepository
	{
		Task<AuthModel> RegisterAsync(RegisterModel model);
		Task<AuthModel> GetTokenAsync(TokenRequestModel model);
		Task<string> AddRoleAsync(AddRoleModel model);
		Task<IReadOnlyList<User>> GetUsers();
		Task<User> GetUser(string userId);

		Task<string> DeleteUser(string id);
		//Task<string> GeneratePasswordResetTokenAsync(string email);
		//Task<bool> ResetPasswordAsync(string email, string token, string newPassword);

	}
}
