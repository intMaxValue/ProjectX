using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Admin;
using ProjectX.ViewModels.Appointment;
using ProjectX.ViewModels.Profile;

namespace ProjectX.Core.Services
{
    /// <summary>
    /// Service responsible for managing user profiles.
    /// </summary>
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;
        private readonly ApplicationDbContext _dbContext;


        public UserProfileService(UserManager<User> userManager, ImageUploader imageUploader, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _imageUploader = imageUploader;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves the complete profile information of a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose profile information is to be retrieved.</param>
        /// <returns>A <see cref="CompleteProfileViewModel"/> object containing the user's profile information.</returns>
        public async Task<CompleteProfileViewModel> GetProfileAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            return new CompleteProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                ProfilePictureUrl = user.ProfilePicture
            };
        }

        /// <summary>
        /// Updates the profile information of a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose profile information is to be updated.</param>
        /// <param name="model">A <see cref="CompleteProfileViewModel"/> containing the updated profile information.</param>
        /// <param name="profilePicture">The new profile picture uploaded by the user.</param>
        /// <returns>True if the profile update was successful, otherwise false.</returns>
        public async Task<bool> UpdateProfileAsync(string userId, CompleteProfileViewModel model, IFormFile profilePicture)
        {
            var currentUser = await _userManager.FindByIdAsync(userId);
            if (currentUser == null)
            {
                return false;
            }

            currentUser.FirstName = model.FirstName;
            currentUser.LastName = model.LastName;
            currentUser.PhoneNumber = model.PhoneNumber;
            currentUser.City = model.City;

            if (profilePicture == null)
            {
                throw new ArgumentException("Profile picture is required.");
            }

            string profilePictureUrl = await _imageUploader.UploadImageAsync(profilePicture);
            currentUser.ProfilePicture = profilePictureUrl;

            var result = await _userManager.UpdateAsync(currentUser);
            return result.Succeeded;
        }

        /// <summary>
        /// Retrieves upcoming appointments for a user.
        /// </summary>
        /// <param name="userId">The ID of the user whose appointments are to be retrieved.</param>
        /// <returns>A list of <see cref="AppointmentViewModel"/> objects representing upcoming appointments.</returns>
        public async Task<List<AppointmentViewModel>> GetUserAppointmentsAsync(string userId)
        {
            var appointments = await _dbContext.Appointments
                .Include(a => a.Salon)
                .Where(a => a.UserId == userId && a.DateAndTime >= DateTime.Now)
                .OrderBy(a => a.DateAndTime)
                .Select(a => new AppointmentViewModel
                {
                    DateTime = a.DateAndTime,
                    SalonName = a.Salon.Name,
                    Comment = a.Comment
                })
                .ToListAsync();

            return appointments;
        }

        /// <summary>
        /// Retrieves a list of all users based on an optional search query.
        /// </summary>
        /// <param name="searchQuery">Optional search query to filter users by first name, last name, city, or phone number.</param>
        /// <returns>A list of <see cref="UserProfileViewModel"/> objects representing user profiles.</returns>
        public async Task<List<UserProfileViewModel>> GetAllUsersAsync(string searchQuery)
        {
            IQueryable<User> query = _userManager.Users;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                query = query.Where(u => u.FirstName.ToLower().Contains(searchQuery) ||
                                         u.LastName.ToLower().Contains(searchQuery) ||
                                         u.City.ToLower().Contains(searchQuery) ||
                                         u.PhoneNumber.ToLower().Contains(searchQuery));
            }

            var users = await query.Select(u => new UserProfileViewModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                City = u.City,
                PhoneNumber = u.PhoneNumber,
                ProfilePictureUrl = u.ProfilePicture,
                UserName = u.UserName,
            })
            .OrderBy(u => u.FirstName)
            .ToListAsync();

            return users;
        }

    }
}
