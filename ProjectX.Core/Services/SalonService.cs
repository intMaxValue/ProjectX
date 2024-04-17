using Microsoft.EntityFrameworkCore;
using ProjectX.Core.Contracts;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;

namespace ProjectX.Core.Services
{
    /// <summary>
    /// Service responsible for managing Salons.
    /// </summary>
    public class SalonService : ISalonService
    {
        private readonly ApplicationDbContext _context;
        public SalonService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a salon by its ID, including associated photos.
        /// </summary>
        /// <param name="id">The ID of the salon to retrieve.</param>
        /// <returns>A <see cref="Salon"/> object representing the salon with the specified ID, or null if not found.</returns>
        public async Task<Salon?> GetSalonByIdAsync(int id)
        {
            var salon = await _context.Salons
                .Include(s => s.Photos)
                .FirstOrDefaultAsync(s => s.Id == id);

            return salon;
        }

        /// <summary>
        /// Retrieves all salons owned by a specific owner, including associated photos, reviews, and appointments.
        /// </summary>
        /// <param name="ownerId">The ID of the owner whose salons are to be retrieved.</param>
        /// <returns>An enumerable collection of <see cref="Salon"/> objects owned by the specified owner.</returns>
        public async Task<IEnumerable<Salon?>> GetAllSalonsByOwnerIdAsync(string ownerId)
        {
            // Retrieve all salons owned by the specified ownerId
            return await _context.Salons
                .Where(s => s.OwnerId == ownerId)
                .Include(s => s.Photos)
                .Include(s => s.Reviews)
                .Include(s => s.Appointments)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a paginated list of salons based on an optional search query.
        /// </summary>
        /// <param name="searchQuery">Optional search query to filter salons by name or city.</param>
        /// <param name="page">The page number to retrieve.</param>
        /// <param name="pageSize">The maximum number of items per page.</param>
        /// <returns>A paginated list of <see cref="Salon"/> objects matching the search criteria.</returns>
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

        /// <summary>
        /// Retrieves the total count of salons based on an optional search query.
        /// </summary>
        /// <param name="searchQuery">Optional search query to filter salons by name or city.</param>
        /// <returns>The total count of salons matching the search criteria.</returns>
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

        /// <summary>
        /// Creates a new salon based on the provided data.
        /// </summary>
        /// <param name="model">A <see cref="CreateSalonViewModel"/> containing the data for the new salon.</param>
        /// <param name="userId">The ID of the user creating the salon.</param>
        /// <returns>The newly created <see cref="Salon"/> object.</returns>
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

        /// <summary>
        /// Adds a new photo to a salon.
        /// </summary>
        /// <param name="salonId">The ID of the salon to add the photo to.</param>
        /// <param name="photoUrl">The URL of the photo to add.</param>
        /// <param name="userId">The ID of the user adding the photo.</param>
        /// <param name="caption">The caption for the photo.</param>
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

        /// <summary>
        /// Retrieves the top cities based on the number of associated salons.
        /// </summary>
        /// <param name="count">The number of top cities to retrieve.</param>
        /// <returns>An enumerable collection of top cities.</returns>
        public async Task<IEnumerable<string>> GetTopCitiesAsync(int count)
        {
            return await _context.Salons
                .GroupBy(s => s.City)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(count)
                .ToListAsync();
        }

        /// <summary>
        /// Updates the details of an existing salon.
        /// </summary>
        /// <param name="salon">The <see cref="Salon"/> object containing the updated details.</param>
        public async Task UpdateSalonAsync(Salon salon)
        {
            // Retrieve the existing salon from the database
            var existingSalon = await _context.Salons.FindAsync(salon.Id);

            // Check if the salon exists
            if (existingSalon == null)
            {
                throw new ArgumentException("Salon not found", nameof(salon.Id));
            }

            // Update the properties of the existing salon with the new values
            existingSalon.Name = salon.Name;
            existingSalon.City = salon.City;
            existingSalon.Address = salon.Address;
            existingSalon.Description = salon.Description;
            existingSalon.PhoneNumber = salon.PhoneNumber;
            existingSalon.MapUrl = salon.MapUrl;
            existingSalon.ProfilePictureUrl = salon.ProfilePictureUrl;

            // Save changes to the database
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a salon and its associated photos.
        /// </summary>
        /// <param name="id">The ID of the salon to delete.</param>
        public async Task DeleteSalonAsync(int id)
        {
            var salon = await _context.Salons.Include(s => s.Photos).FirstOrDefaultAsync(s => s.Id == id);
            if (salon != null)
            {
                // Delete all associated photos first
                foreach (var photo in salon.Photos.ToList())
                {
                    _context.Photos.Remove(photo);
                }

                _context.Salons.Remove(salon);
                await _context.SaveChangesAsync();
            }
        }

    }
}
