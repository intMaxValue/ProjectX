using Microsoft.AspNetCore.SignalR;
using ProjectX.ViewModels.Chat;
using System;
using System.Threading.Tasks;
using ProjectX.Core.Contracts;

namespace ProjectX.Core.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task SendMessage(string user, string message, int salonId)
        {
            var timestampUtc = DateTime.UtcNow;
            var timestampLocal = timestampUtc.ToLocalTime(); // Convert UTC timestamp to local time

            // Retrieve the senderId based on the current user's identity
            var senderId = Context.UserIdentifier;
            if (senderId == null)
            {
                throw new InvalidOperationException("Sender ID not found.");
            }

            // Save the message to the database using the injected service
            await _chatService.SendMessageAsync(new ChatMessageViewModel
            {
                SenderName = user,
                Content = message,
                Timestamp = timestampLocal // Use local time zone timestamp
            }, senderId, salonId);

            // Broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message, timestampLocal.ToString("yyyy-MM-dd HH:mm:ss"), salonId);
        }

    }
}