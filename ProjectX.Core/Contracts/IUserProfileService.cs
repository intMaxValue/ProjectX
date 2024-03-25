using Microsoft.AspNetCore.Http;
using ProjectX.ViewModels.Profile;

namespace ProjectX.Core.Contracts
{
    public interface IUserProfileService
    {
        Task<CompleteProfileViewModel> GetProfileAsync(string userId);
        Task<bool> UpdateProfileAsync(string userId, CompleteProfileViewModel model, IFormFile profilePicture);
    }
}
