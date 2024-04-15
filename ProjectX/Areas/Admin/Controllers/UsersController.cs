using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Admin;

namespace ProjectX.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserProfileService _userService;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UsersController(IUserProfileService userService, UserManager<User> userManager, ApplicationDbContext context)
        {
            _userService = userService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchQuery)
        {
            var users = await _userService.GetAllUsersAsync(searchQuery);
            ViewBag.SearchQuery = searchQuery;

            // Iterate through each user and set IsSalonOwner based on their roles
            foreach (var user in users)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);
                if (currentUser != null)
                {
                    user.IsSalonOwner = await _userManager.IsInRoleAsync(currentUser, "SalonOwner");
                }
            }

            return View(users);
        }

        public async Task<IActionResult> UserProfileDetails(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var model = new UserProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                ProfilePictureUrl = user.ProfilePicture,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };

            return View(model);
        }
    }
}