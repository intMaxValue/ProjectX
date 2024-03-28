using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Core.Services
{
    public class SalonService : ISalonService
    {
        private readonly ApplicationDbContext _context;
        public SalonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Salon?> GetSalonByIdAsync(int id)
        {
            var salon = await _context.Salons
                .Include(s => s.Photos)
                .Include(s => s.Reviews)
                .Include(s => s.Appointments)
                .Include(s => s.Availabilities)
                .FirstOrDefaultAsync(s => s.Id == id);

            return salon ?? throw new Exception("Salon not found");
        }

        public async Task<IEnumerable<Salon?>> GetAllSalonsByOwnerIdAsync(string ownerId)
        {
            // Retrieve all salons owned by the specified ownerId
            return await _context.Salons
                .Where(s => s.OwnerId == ownerId)
                .Include(s => s.Photos)
                .Include(s => s.Reviews)
                .Include(s => s.Appointments)
                .Include(s => s.Availabilities)
                .ToListAsync();
        }


        public async Task<IEnumerable<Salon>> GetPaginatedSalonsAsync(string searchQuery, int page, int pageSize)
        {
            IQueryable<Salon> query = _context.Salons;

            // Apply search filter if searchQuery is provided
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery) || s.City.Contains(searchQuery));
            }

            // Apply pagination
            var paginatedSalons = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return paginatedSalons;
        }

        public async Task<int> GetAllSalonsCountAsync(string searchQuery)
        {
            IQueryable<Salon> query = _context.Salons;

            // Apply search filter if searchQuery is provided
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(s => s.Name.Contains(searchQuery) || s.City.Contains(searchQuery));
            }

            // Return the total count of salons
            return await query.CountAsync();
        }


        public async Task<Salon> CreateSalonAsync(CreateSalonViewModel model, string userId)
        {
            var salon = new Salon()
            {
                Name = model.Name,
                City = model.City,
                Address = model.Address,
                Description = model.Description,
                OwnerId = userId,
                PhoneNumber = model.PhoneNumber,
                MapUrl = model.MapUrl,
                ProfilePictureUrl = model.ProfilePictureUrl,
            };

            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();
            return salon;
        }

        public async Task AddPhotoToSalonAsync(int salonId, string photoUrl, string userId, string caption)
        {
            // Find the salon by its ID
            var salon = await _context.Salons.FindAsync(salonId);

            if (salon == null)
            {
                throw new ArgumentException("Salon not found", nameof(salonId));
            }

            // Ensure that the current user is the owner of the salon
            if (salon.OwnerId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to add photos to this salon.");
            }

            var newPhoto = new Photo
            {
                Url = photoUrl,
                Caption = caption,
                DateUploaded = DateTime.UtcNow,
                SalonId = salonId,
                UserId = userId
            };

            // Add photo to the context
            _context.Photos.Add(newPhoto);

            // Save changes to the database
            await _context.SaveChangesAsync();
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
