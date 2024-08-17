using AntiFishing.Api.Hubs;
using AntiFishing.Data.Entities;
using Microsoft.AspNetCore.SignalR;

namespace AntiFishing.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChatController : ControllerBase
	{
		private readonly IHubContext<ChatHub> _hubcontext;
		private readonly ApplicationDbContext _dbContext;
		public ChatController(IHubContext<ChatHub> hubcontext, ApplicationDbContext dbContext)
		{
			_hubcontext = hubcontext;
			_dbContext = dbContext;
		}
		[HttpPost("send")]
		public async Task<IActionResult> SendMessage([FromBody] ChatMessage messageDto)
		{
			try
			{

				var chatMessage = new ChatMessage
				{
					Name = messageDto.Name,
					Message = messageDto.Message,
					DateTime = DateTime.Now
				};


				_dbContext.ChatMessages.Add(chatMessage);
				await _dbContext.SaveChangesAsync();


				await _hubcontext.Clients.All.SendAsync("ReceiveMessage", chatMessage);

				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}
		[HttpGet("messages")]
		public async Task<IActionResult> GetMessages()
		{
			try
			{
				var messages = await _dbContext.ChatMessages.ToListAsync();
				return Ok(messages);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}




	}
}



