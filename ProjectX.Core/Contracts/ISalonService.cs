using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Core.Contracts
{
    public interface ISalonService
    {
        Task<IEnumerable<Salon>> GetAllSalonsAsync(string searchQuery);
        Task<Salon?> GetSalonByIdAsync(int id);
        Task<Salon> CreateSalonAsync(Salon salon);
        Task DeleteSalonAsync(int id);
    }
}
