using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Appointment;
using ProjectX.ViewModels.Chat;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data;

namespace ProjectX.Controllers
{
    /// <summary>
    /// Controller for managing chat functionality within salons.
    /// </summary>
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly ISalonService _salonService;
        private readonly ApplicationDbContext _dbContext;

        public ChatController(IChatService chatService, ISalonService salonService, ApplicationDbContext dbContext)
        {
            _chatService = chatService;
            _salonService = salonService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Displays the chat room for a specific salon.
        /// </summary>
        /// <param name="salonId">The ID of the salon.</param>
        /// <returns>The view displaying the chat room.</returns>
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
                SalonOwnerId = salon.OwnerId,
                SalonProfilePictureUrl = salon.ProfilePictureUrl,
                SalonName = salon.Name
            };

            ViewBag.CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(viewModel);
        }

        /// <summary>
        /// Sends a message to the chat room of a specific salon.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        /// <param name="salonId">The ID of the salon.</param>
        /// <returns>Redirects to the chat room view.</returns>
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

        /// <summary>
        /// Creates a new appointment for a user in a specific salon.
        /// </summary>
        /// <param name="senderName">The name of the sender.</param>
        /// <param name="dateTime">The date and time of the appointment.</param>
        /// <param name="comment">Optional comment for the appointment.</param>
        /// <param name="salonId">The ID of the salon.</param>
        /// <returns>ActionResult indicating the success or failure of the appointment creation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(string senderName, DateTime dateTime, string comment, int salonId)
        {
            try
            {
                var userId = await _dbContext.Users
                    .Where(u => u.UserName == senderName)
                    .Select(u => u.Id)
                    .FirstOrDefaultAsync();

                if (userId == null)
                {
                    return BadRequest("User not found.");
                }

                var appointment = new Appointment
                {
                    DateAndTime = dateTime,
                    Comment = comment,
                    UserId = userId,
                    SalonId = salonId,
                };

                _dbContext.Appointments.Add(appointment);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create appointment: {ex.Message}");
            }
        }


    }
}
