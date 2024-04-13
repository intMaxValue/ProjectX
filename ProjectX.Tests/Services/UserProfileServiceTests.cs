using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.ViewModels.Appointment;
using ProjectX.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProjectX.Tests.Services
{
    [TestFixture]
    public class UserProfileServiceTests
    {
        private UserProfileService _userProfileService;
        private Mock<UserManager<User>> _userManagerMock;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new ApplicationDbContext(options);

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var storeMock = new Mock<IUserStore<User>>();
            var optionsAccessorMock = new Mock<IOptions<IdentityOptions>>();
            var passwordHasherMock = new Mock<IPasswordHasher<User>>();
            var userValidatorsMock = new List<IUserValidator<User>>();
            var passwordValidatorsMock = new List<IPasswordValidator<User>>();
            var keyNormalizerMock = new Mock<ILookupNormalizer>();
            var errorsMock = new Mock<IdentityErrorDescriber>();
            var loggerMock = new Mock<ILogger<UserManager<User>>>();
            

            _userManagerMock = new Mock<UserManager<User>>(
                storeMock.Object,
                optionsAccessorMock.Object,
                passwordHasherMock.Object,
                userValidatorsMock,
                passwordValidatorsMock,
                keyNormalizerMock.Object,
                errorsMock.Object,
                serviceProvider,
                loggerMock.Object
            );

            // Mocking FindByIdAsync to return a user
            var userId = "user-id";
            var user = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                City = "New York",
                PhoneNumber = "123456789",
                ProfilePicture = "profile-picture-url"
            };
            _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync(user);

            _userProfileService = new UserProfileService(_userManagerMock.Object, new ImageUploader(new HttpClient(), "clientId"), dbContext);
        }

        [Test]
        public async Task GetProfileAsync_UserFound_ReturnsCompleteProfileViewModel()
        {
            // Arrange
            var userId = "user-id";
            var expectedProfileViewModel = new CompleteProfileViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                City = "New York",
                PhoneNumber = "123456789",
                ProfilePictureUrl = "profile-picture-url"
            };

            // Act
            var result = await _userProfileService.GetProfileAsync(userId);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo(expectedProfileViewModel.FirstName));
            Assert.That(result.LastName, Is.EqualTo(expectedProfileViewModel.LastName));
            Assert.That(result.City, Is.EqualTo(expectedProfileViewModel.City));
            Assert.That(result.PhoneNumber, Is.EqualTo(expectedProfileViewModel.PhoneNumber));
            Assert.That(result.ProfilePictureUrl, Is.EqualTo(expectedProfileViewModel.ProfilePictureUrl));
        }

        [Test]
        public async Task UpdateProfileAsync_UserNotFound_ReturnsFalse()
        {
            // Arrange
            var userId = "user-id";
            var model = new CompleteProfileViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                City = "New York",
                PhoneNumber = "123456789"
            };
            var profilePicture = new Mock<IFormFile>().Object;

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            _userManagerMock.Setup(u => u.FindByIdAsync(userId)).ReturnsAsync((User)null);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

            // Act
            var result = await _userProfileService.UpdateProfileAsync(userId, model, profilePicture);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdateProfileAsync_NullProfilePicture_ThrowsArgumentException()
        {
            // Arrange
            var userId = "user-id";
            var model = new CompleteProfileViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                City = "New York",
                PhoneNumber = "123456789"
            };

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(async () => await _userProfileService.UpdateProfileAsync(userId, model, null!));
        }

        [Test]
        public async Task GetUserAppointmentsAsync_ReturnsAppointmentsForUser()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new ApplicationDbContext(options);

            var userId = "user-id";
            var expectedAppointments = await dbContext.Appointments
                .Where(a => a.UserId == userId && a.DateAndTime >= DateTime.Now)
                .OrderBy(a => a.DateAndTime)
                .Select(a => new AppointmentViewModel
                {
                    DateTime = a.DateAndTime,
                    SalonName = a.Salon.Name,
                    Comment = a.Comment
                })
                .ToListAsync();

            // Act
            var result = await _userProfileService.GetUserAppointmentsAsync(userId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedAppointments.Count));
            for (int i = 0; i < expectedAppointments.Count; i++)
            {
                Assert.That(result[i].DateTime, Is.EqualTo(expectedAppointments[i].DateTime));
                Assert.That(result[i].SalonName, Is.EqualTo(expectedAppointments[i].SalonName));
                Assert.That(result[i].Comment, Is.EqualTo(expectedAppointments[i].Comment));
            }
        }
    }
}
