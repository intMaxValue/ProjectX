using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models.Chat;
using ProjectX.ViewModels.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjectX.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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



        public async Task<IEnumerable<ChatMessageViewModel>> GetChatMessagesForRoomAsync(int chatRoomId, ClaimsPrincipal user)
        {
            var userName = user.Identity.Name;

            var chatMessages = await _dbContext.ChatMessages
                .Where(m => m.ChatRoomId == chatRoomId)
                .OrderBy(m => m.DateAndTime)
                .Select(message => new ChatMessageViewModel
                {
                    SenderName = message.UserName ?? "Unknown",
                    Content = message.Content,
                    Timestamp = message.DateAndTime
                })
                .ToListAsync();

            return chatMessages;
        }


        public async Task SendMessageAsync(ChatMessageViewModel message, int chatRoomId, string senderId)
        {
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
                ChatRoomId = chatRoomId,
                Content = message.Content,
                DateAndTime = DateTime.UtcNow,
                SenderId = senderId,
                UserName = username
            };

            _dbContext.ChatMessages.Add(chatMessage);
            await _dbContext.SaveChangesAsync();
        }



        public async Task<User> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            return user;
        }
    }
}