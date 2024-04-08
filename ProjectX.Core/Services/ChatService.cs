using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data.Models.Chat;
using ProjectX.ViewModels.Chat;

namespace ProjectX.Core.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISalonService _salonService;
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatService(ApplicationDbContext dbContext, ISalonService salonService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _salonService = salonService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ChatMessageViewModel>> GetChatMessagesForRoomAsync(int salonId, ClaimsPrincipal user)
        {
            var userName = user.Identity.Name;

            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(room => room.SalonId == salonId);

            if (chatRoom == null)
            {
                // Handle case where chat room does not exist for the given salonId
                return new List<ChatMessageViewModel>(); // Return an empty list
            }
            var chatMessages = await _dbContext.ChatMessages
                .Where(m => m.ChatRoomId == chatRoom.Id) // Filter by chat room ID
                .OrderBy(m => m.DateAndTime)
                .Select(message => new ChatMessageViewModel
                {
                    SenderName = message.UserName ?? "Unknown",
                    Content = message.Content,
                    Timestamp = message.DateAndTime.ToLocalTime()
                })
                .ToListAsync();

            return chatMessages;
        }

        public async Task SendMessageAsync(ChatMessageViewModel message, string senderId, int salonId)
        {
            // Check if the chat room with the specified salonId exists
            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(room => room.SalonId == salonId);

            // If chat room does not exist, create a new one
            if (chatRoom == null)
            {
                chatRoom = new ChatRoom { SalonId = salonId };
                _dbContext.ChatRooms.Add(chatRoom);
                await _dbContext.SaveChangesAsync();
            }

            // Retrieve the User object associated with the senderId
            var user = await _userManager.FindByIdAsync(senderId);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            // Assuming 'user' has a UserName property
            string username = user.UserName;

            var chatMessage = new ChatMessage
            {
                ChatRoomId = chatRoom.Id, // Use the generated chat room ID
                Content = message.Content,
                DateAndTime = DateTime.UtcNow,
                SenderId = senderId,
                UserName = username
            };

            _dbContext.ChatMessages.Add(chatMessage);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DoesChatRoomExistAsync(int salonId)
        {
            return await _dbContext.ChatRooms.AnyAsync(room => room.SalonId == salonId);
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
        }
    }
}
