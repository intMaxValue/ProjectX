using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Core.Contracts
{
    public interface ISalonService
    {
        Task<Salon?> GetSalonByIdAsync(int id);
        Task<IEnumerable<Salon?>> GetAllSalonsByOwnerIdAsync(string ownerId);
        Task<Salon> CreateSalonAsync(CreateSalonViewModel model, string userId);
        Task DeleteSalonAsync(int id);
        Task<IEnumerable<Salon>> GetPaginatedSalonsAsync(string searchQuery, int page, int pageSize);
        Task<int> GetAllSalonsCountAsync(string searchQuery);
    }
}