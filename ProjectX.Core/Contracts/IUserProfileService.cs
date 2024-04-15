using Microsoft.AspNetCore.Http;
using ProjectX.ViewModels.Admin;
using ProjectX.ViewModels.Appointment;
using ProjectX.ViewModels.Profile;

namespace ProjectX.Core.Contracts
{
    public interface IUserProfileService
    {
        Task<CompleteProfileViewModel> GetProfileAsync(string userId);
        Task<bool> UpdateProfileAsync(string userId, CompleteProfileViewModel model, IFormFile profilePicture);
        Task<List<AppointmentViewModel>> GetUserAppointmentsAsync(string userId);
        Task<List<UserProfileViewModel>> GetAllUsersAsync(string searchQuery);
    }
}
