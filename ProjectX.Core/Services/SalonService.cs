using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;

namespace ProjectX.Core.Services
{
    public class SalonService : ISalonService
    {
        private readonly ApplicationDbContext _context;

        public SalonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salon>> GetAllSalonsAsync(string searchQuery)
        {
            IQueryable<Salon> query = _context.Salons;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery) || s.City.Contains(searchQuery));
            }

            return await query.ToListAsync();
        }

        public async Task<Salon?> GetSalonByIdAsync(int id)
        {
            var salon = await _context.Salons
                .Include(s => s.Photos)
                .Include(s => s.Reviews)
                .Include(s => s.Appointments)
                .Include(s => s.Availabilities)
                .FirstOrDefaultAsync(s => s.Id == id);

            return salon == null ? throw new Exception("Salon not found") : salon;
        }


        public async Task<Salon> CreateSalonAsync(Salon salon)
        {
            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task DeleteSalonAsync(int id)
        {
            var salon = await _context.Salons.FindAsync(id);
            if (salon != null)
            {
                _context.Salons.Remove(salon);
                await _context.SaveChangesAsync();
            }
        }

    }
}
