using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.ViewModels.Appointment;
using ProjectX.ViewModels.Chat;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data;

namespace ProjectX.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the view model to the Appointment entity
                var appointment = new Appointment
                {
                    DateAndTime = model.DateTime,
                    Comment = model.Comment,
                    SalonId = model.SalonId,
                    UserId = model.UserId // Assign UserId from the view model
                };

                // Add the appointment to the database
                _dbContext.Appointments.Add(appointment);
                await _dbContext.SaveChangesAsync();

                // Return a success response
                return Ok();
            }
            else
            {
                // Return validation errors
                return BadRequest(ModelState);
            }
        }

    }
}
