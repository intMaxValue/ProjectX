using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Salon;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Tests.Services
{
    [TestFixture]
    public class SalonServiceTests
    {
        private ApplicationDbContext _dbContext;
        private SalonService _salonService;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_" + TestContext.CurrentContext.Test.Name) // Unique database name for each test
                .Options;

            _dbContext = new ApplicationDbContext(dbContextOptions);
            _salonService = new SalonService(_dbContext);
        }

        [TearDown]
        public void Teardown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetSalonByIdAsync_ValidId_ReturnsSalon()
        {
            // Arrange
            int salonId = 123;
            var expectedSalon = new Salon { Id = salonId, Name = "Test Salon" };
            await _dbContext.Salons.AddAsync(expectedSalon);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _salonService.GetSalonByIdAsync(salonId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedSalon));
        }

        [Test]
        public async Task GetAllSalonsByOwnerIdAsync_ValidOwnerId_ReturnsSalons()
        {
            // Arrange
            var ownerId = "test-owner-id";
            var expectedSalons = new List<Salon>
            {
                new Salon { Id = 111, Name = "Salon 1", OwnerId = ownerId, City = "City 1", Address = "Address 1" },
                new Salon { Id = 222, Name = "Salon 2", OwnerId = ownerId, City = "City 2", Address = "Address 2" }
            };
            foreach (var salon in expectedSalons)
            {
                await _dbContext.Salons.AddAsync(salon);
            }
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _salonService.GetAllSalonsByOwnerIdAsync(ownerId);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedSalons));
        }

        [Test]
        public async Task GetPaginatedSalonsAsync_ValidQuery_ReturnsPaginatedSalons()
        {
            // Arrange
            var searchQuery = "Test";
            var page = 1;
            var pageSize = 2;
            var expectedSalons = new List<Salon>
            {
                new Salon { Id = 121, Name = "Salon 1", City = "Test City 1", Address = "Address 1" },
                new Salon { Id = 212, Name = "Salon 2", City = "Test City 2", Address = "Address 2" }
            };
            foreach (var salon in expectedSalons)
            {
                await _dbContext.Salons.AddAsync(salon);
            }
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _salonService.GetPaginatedSalonsAsync(searchQuery, page, pageSize);

            // Assert
            Assert.That(result.Select(s => new { s.Id, s.Name, s.City, s.Address }), Is.EqualTo(expectedSalons.Select(s => new { s.Id, s.Name, s.City, s.Address })));
        }

        [Test]
        public async Task GetAllSalonsCountAsync_ValidSearchQuery_ReturnsSalonsCount()
        {
            // Arrange
            var searchQuery = "Test";
            var expectedCount = 2;
            await _dbContext.Salons.AddRangeAsync(
                new List<Salon>
                {
                    new Salon { Id = 1, Name = "Salon 1", City = "Test City 1" },
                    new Salon { Id = 2, Name = "Salon 2", City = "Test City 2" }
                });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _salonService.GetAllSalonsCountAsync(searchQuery);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task CreateSalonAsync_ValidModel_ReturnsCreatedSalon()
        {
            // Arrange
            var model = new CreateSalonViewModel
            {
                Name = "Test Salon",
                City = "Test City",
                Address = "Test Address"
            };
            var userId = "test-user-id";

            // Act
            var result = await _salonService.CreateSalonAsync(model, userId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo(model.Name));
            Assert.That(result.City, Is.EqualTo(model.City));
            Assert.That(result.Address, Is.EqualTo(model.Address));
            Assert.That(result.OwnerId, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetTopCitiesAsync_ReturnsTopCities()
        {
            // Arrange
            var expectedCities = new List<string> { "City1", "City2", "City3" };
            var salons = new List<Salon>
    {
        new Salon { Id = 1, City = "City1" },
        new Salon { Id = 2, City = "City2" },
        new Salon { Id = 3, City = "City1" },
        new Salon { Id = 4, City = "City3" },
        new Salon { Id = 5, City = "City2" }
    };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using var dbContext = new ApplicationDbContext(dbContextOptions);
            await dbContext.Salons.AddRangeAsync(salons);
            await dbContext.SaveChangesAsync();

            var salonService = new SalonService(dbContext);

            // Act
            var result = await salonService.GetTopCitiesAsync(3);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedCities));
        }

        [Test]
        public async Task GetTopCitiesAsync_WithCountGreaterThanAvailableCities_ReturnsAllCities()
        {
            // Arrange
            var expectedCities = new List<string> { "City1", "City2", "City3" };
            var salons = new List<Salon>
            {
                new Salon { Id = 11, City = "City1" },
                new Salon { Id = 22, City = "City2" },
                new Salon { Id = 33, City = "City1" },
                new Salon { Id = 44, City = "City3" },
                new Salon { Id = 55, City = "City2" }
            };

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using var dbContext = new ApplicationDbContext(dbContextOptions);
            await dbContext.Salons.AddRangeAsync(salons);
            await dbContext.SaveChangesAsync();

            var salonService = new SalonService(dbContext);

            // Act
            var result = await salonService.GetTopCitiesAsync(5);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedCities));
        }

        [Test]
        public async Task GetTopCitiesAsync_WithEmptyDatabase_ReturnsEmptyList()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database_" + TestContext.CurrentContext.Test.Name)
                .Options;

            using var dbContext = new ApplicationDbContext(dbContextOptions);
            var salonService = new SalonService(dbContext);

            // Act
            var result = await salonService.GetTopCitiesAsync(3);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task UpdateSalonAsync_SalonExists_UpdatesSalon()
        {
            // Arrange
            var existingSalon = new Salon { Id = 123, Name = "Existing Salon", City = "Existing City", Address = "Existing Address" };
            await _dbContext.Salons.AddAsync(existingSalon);
            await _dbContext.SaveChangesAsync();

            var updatedSalon = new Salon
            {
                Id = existingSalon.Id,
                Name = "Updated Salon",
                City = "Updated City",
                Address = "Updated Address",
                Description = "Updated Description",
                PhoneNumber = "Updated PhoneNumber",
                MapUrl = "Updated MapUrl",
                ProfilePictureUrl = "Updated ProfilePictureUrl"
            };

            // Act
            await _salonService.UpdateSalonAsync(updatedSalon);

            // Assert
            var salonInDb = await _dbContext.Salons.FindAsync(existingSalon.Id);
            Assert.That(salonInDb, Is.Not.Null);
            Assert.That(salonInDb.Name, Is.EqualTo(updatedSalon.Name));
            Assert.That(salonInDb.City, Is.EqualTo(updatedSalon.City));
            Assert.That(salonInDb.Address, Is.EqualTo(updatedSalon.Address));
            Assert.That(salonInDb.Description, Is.EqualTo(updatedSalon.Description));
            Assert.That(salonInDb.PhoneNumber, Is.EqualTo(updatedSalon.PhoneNumber));
            Assert.That(salonInDb.MapUrl, Is.EqualTo(updatedSalon.MapUrl));
            Assert.That(salonInDb.ProfilePictureUrl, Is.EqualTo(updatedSalon.ProfilePictureUrl));
        }

        [Test]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UpdateSalonAsync_SalonDoesNotExist_ThrowsArgumentException()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Arrange
            var salonToUpdate = new Salon { Id = 123, Name = "Non-existing Salon" };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _salonService.UpdateSalonAsync(salonToUpdate));
        }

        [Test]
        public async Task DeleteSalonAsync_SalonExists_RemovesSalonAndAssociatedPhotos()
        {
            // Arrange
            var salonId = 123;
            var salon = new Salon { Id = salonId, Name = "Test Salon" };
            var photo1 = new Photo { Id = 1, SalonId = salonId, Url = "photo1.jpg" };
            var photo2 = new Photo { Id = 2, SalonId = salonId, Url = "photo2.jpg" };

            await _dbContext.Salons.AddAsync(salon);
            await _dbContext.Photos.AddRangeAsync(photo1, photo2);
            await _dbContext.SaveChangesAsync();

            // Act
            await _salonService.DeleteSalonAsync(salonId);

            // Assert
            var deletedSalon = await _dbContext.Salons.FindAsync(salonId);
            var deletedPhotos = await _dbContext.Photos.Where(p => p.SalonId == salonId).ToListAsync();

            Assert.That(deletedSalon, Is.Null);
            Assert.That(deletedPhotos, Is.Empty);
        }

        [Test]
        public async Task DeleteSalonAsync_SalonDoesNotExist_DoesNothing()
        {
            // Arrange
            var salonId = 123;

            // Act
            await _salonService.DeleteSalonAsync(salonId);

            // Assert
            var deletedSalon = await _dbContext.Salons.FindAsync(salonId);
            Assert.That(deletedSalon, Is.Null);
        }

    }
}
