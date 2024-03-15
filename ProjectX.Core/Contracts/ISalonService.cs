using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Core.Contracts
{
    public interface ISalonService
    {
        Task<IEnumerable<Salon>> GetAllSalonsAsync(string searchQuery);
        Task<Salon?> GetSalonByIdAsync(int id);
        Task<Salon> CreateSalonAsync(CreateSalonViewModel model, string userId);
        Task DeleteSalonAsync(int id);
    }
}
