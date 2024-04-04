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

        public async Task SendMessage(string user, string message, int chatRoomId)
        {
            var timestamp = DateTime.UtcNow;

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
                Timestamp = timestamp,
                ChatRoomId = chatRoomId
            }, chatRoomId, senderId);

            // Broadcast the message to all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message, timestamp.ToString("yyyy-MM-dd HH:mm:ss"), chatRoomId);
        }

    }
}