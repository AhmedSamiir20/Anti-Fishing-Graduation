namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _authRepository;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		//private readonly EmailService _emailService;

		public AuthController(IAuthRepository authRepository, IMapper mapper)
		{
			_authRepository = authRepository;
			_mapper = mapper;
		}
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _authRepository.RegisterAsync(model);

			if (!result.IsAuthenticated)
				return BadRequest(result.Message);

			return Ok(result);
		}


		[HttpPost("token")]
		public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var user = await _authRepository.GetTokenAsync(model);

			if (!user.IsAuthenticated)
				return BadRequest(user.Message);

			return Ok(user);
		}


		[HttpPost("addrole")]
		public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _authRepository.AddRoleAsync(model);

			if (!string.IsNullOrEmpty(result))
				return BadRequest(result);

			return Ok(model);
		}

		[HttpGet("UsersName")]
		public async Task<IActionResult> GetUsersNameAsync()
		{
			var users = await _authRepository.GetUsers();

			if (!users.Any())
				return BadRequest(users);

			var respone = _mapper.Map<IReadOnlyList<GetNameUserResponse>>(users);
			return Ok(respone);
		}

		[HttpGet("Users")]
		public async Task<IActionResult> GetUsersAsync()
		{
			var users = await _authRepository.GetUsers();

			if (!users.Any())
				return BadRequest(users);

			var response = _mapper.Map<IReadOnlyList<GetUserResponse>>(users);
			return Ok(response);
		}
		[HttpGet("UserById")]
		public async Task<IActionResult> GetUserAsync(string userId)
		{
			var user = await _authRepository.GetUser(userId);

			if (user is null)
				return BadRequest("There is no User by this id");

			var response = _mapper.Map<GetUserResponse>(user);
			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(string id)
		{
			var result = await _authRepository.DeleteUser(id);
			return Ok(result);
		}

		// Add this method to your AuthController
		[Authorize]
		[HttpGet("profile")]
		public async Task<IActionResult> GetProfile()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var user = await _authRepository.GetUser(userId);

			if (user == null)
			{
				return NotFound("User not found");
			}

			var response = _mapper.Map<GetUserResponse>(user);
			return Ok(response);
		}

	}
}
