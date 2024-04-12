using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Reviews;

namespace ProjectX.Core.Contracts
{
    public interface IReviewService
    {
        Task<IList<ReviewViewModel>> GetReviewsForSalonAsync(int salonId);
        Task CreateReviewAsync(ReviewViewModel review);
        Task<Review?> GetReviewByIdAsync(int id);
        Task UpdateReviewAsync(ReviewViewModel review);
        Task DeleteReviewAsync(int id);
        Task<string> GetSalonProfilePictureAsync(int salonId);
    }
}
