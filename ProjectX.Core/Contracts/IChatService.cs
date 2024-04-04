using ProjectX.ViewModels.Chat;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectX.Core.Contracts
{
    public interface IChatService
    {
        Task<IEnumerable<ChatMessageViewModel>> GetChatMessagesForRoomAsync(int chatRoomId, ClaimsPrincipal user);
        Task SendMessageAsync(ChatMessageViewModel message, int chatRoomId, string senderId);

    }
}