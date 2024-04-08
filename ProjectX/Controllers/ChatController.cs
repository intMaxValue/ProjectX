using Microsoft.AspNetCore.Mvc;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Chat;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectX.Controllers
{
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly ISalonService _salonService;

        public ChatController(IChatService chatService, ISalonService salonService)
        {
            _chatService = chatService;
            _salonService = salonService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int salonId)
        {
            var salon = await _salonService.GetSalonByIdAsync(salonId);

            if (salon == null)
            {
                // Salon not found, handle accordingly (e.g., return a 404 Not Found view)
                return NotFound();
            }

            var viewModel = new SalonChatViewModel
            {
                Messages = (await _chatService.GetChatMessagesForRoomAsync(salonId, HttpContext.User)).ToList(),
                SalonId = salonId,
                SalonProfilePictureUrl = salon.ProfilePictureUrl,
                SalonName = salon.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(ChatMessageViewModel message, int salonId)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, return to the chat room view with validation errors
                return RedirectToAction(nameof(Index), new { salonId });
            }

            // Retrieve the sender's user ID from the claims
            string senderId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Send the message to the chat room
            await _chatService.SendMessageAsync(message, senderId, salonId);

            // Redirect to the chat room view
            return RedirectToAction(nameof(Index), new { salonId = salonId });
        }
    }
}
