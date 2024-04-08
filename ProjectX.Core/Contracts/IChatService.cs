using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Chat;

namespace ProjectX.Core.Contracts
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessageViewModel>> GetChatMessagesForRoomAsync(int salonId, ClaimsPrincipal user);
        Task SendMessageAsync(ChatMessageViewModel message, string senderId, int salonId);
        Task<bool> DoesChatRoomExistAsync(int salonId);
        Task<User> GetCurrentUserAsync();
    }
}