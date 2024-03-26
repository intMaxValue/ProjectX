using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Profile;

namespace ProjectX.Core.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly ImageUploader _imageUploader;

        public UserProfileService(UserManager<User> userManager, ImageUploader imageUploader)
        {
            _userManager = userManager;
            _imageUploader = imageUploader;
        }

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

    }
}
