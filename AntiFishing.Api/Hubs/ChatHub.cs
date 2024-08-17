using AntiFishing.Data.Entities;
using Microsoft.AspNetCore.SignalR;

namespace AntiFishing.Api.Hubs
{
	public class ChatHub : Hub
	{
		private readonly ApplicationDbContext _Context;
		private static readonly List<ChatMessage> chatMessages = new List<ChatMessage>();

		public ChatHub(ApplicationDbContext dbContext)
		{
			_Context = dbContext;
		}
		public void BrodcastEmployee(ChatMessage chat)
		{
			// Save the message to the database

			_Context.ChatMessages.Add(chat);
			_Context.SaveChangesAsync();
			Clients.All.SendAsync("ReceiveMessage", chat);
		}

		public async Task SendMessage(ChatMessage chatMessage)
		{
			_Context.ChatMessages.Add(chatMessage);
			await _Context.SaveChangesAsync();
			await Clients.All.SendAsync("ReceiveMessage", chatMessage);
		}
		public async Task RequestChatHistory()
		{
			var chatHistory = await _Context.ChatMessages
				 .OrderBy(msg => msg.DateTime)
				 .ToListAsync();

			await Clients.Caller.SendAsync("ReceiveChatHistory", chatHistory);
		}
	}
}