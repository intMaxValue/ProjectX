using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ProjectX.Core.Contracts;
using ProjectX.Core.Services;
using ProjectX.Infrastructure.Data;
using ProjectX.Infrastructure.Data.Models;
using ProjectX.Infrastructure.Data.Models.Chat;
using ProjectX.ViewModels.Chat;

namespace ProjectX.Tests.Services
{
    [TestFixture]
    public class ChatServiceTests
    {
        private ApplicationDbContext _dbContext;
        private ChatService _chatService;
        private Mock<UserManager<User>> _mockUserManager;
        private Mock<ISalonService> _mockSalonService;
        private Mock<IHttpContextAccessor> _mockHttpContextAccessor;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _dbContext = new ApplicationDbContext(options);

            _mockUserManager = MockUserManager<User>();
            _mockSalonService = new Mock<ISalonService>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            _chatService = new ChatService(_dbContext, _mockSalonService.Object, _mockUserManager.Object, _mockHttpContextAccessor.Object);
        }

        [TearDown]
        public void Dispose()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetChatMessagesForRoomAsync_ChatRoomExists_ReturnsMessages()
        {
            // Arrange
            var salonId = 1; // Provide a valid salonId
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "username"),
                new Claim(ClaimTypes.NameIdentifier, "userId"),
            }));

            var chatRoom = new ChatRoom { Id = 1, SalonId = salonId }; // Create a ChatRoom object
            _dbContext.ChatRooms.Add(chatRoom);
            await _dbContext.SaveChangesAsync();

            var chatMessages = new List<ChatMessage>
            {
                new ChatMessage { Id = 1, ChatRoomId = chatRoom.Id, Content = "Message 1", DateAndTime = DateTime.Now },
                new ChatMessage { Id = 2, ChatRoomId = chatRoom.Id, Content = "Message 2", DateAndTime = DateTime.Now },
                // Add more chat messages as needed
            };
            _dbContext.ChatMessages.AddRange(chatMessages);
            await _dbContext.SaveChangesAsync();

            _mockHttpContextAccessor.Setup(m => m!.HttpContext!.User).Returns(user);

            // Act
            var result = await _chatService.GetChatMessagesForRoomAsync(salonId, user);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(chatMessages.Count));
        }

        [Test]
        public async Task SendMessageAsync_NewChatRoom_CreatesNewChatRoomAndMessage()
        {
            // Arrange
            var salonId = 2;
            var senderId = "userId";
            var message = new ChatMessageViewModel { Content = "Test Message" };

            _mockUserManager.Setup(m => m.FindByIdAsync(senderId))
                .ReturnsAsync(new User { Id = senderId, UserName = "senderUserName" });

            // Act
            await _chatService.SendMessageAsync(message, senderId, salonId);

            // Assert
            var chatRoom = await _dbContext.ChatRooms.FirstOrDefaultAsync(room => room.SalonId == salonId);
            Assert.NotNull(chatRoom);

            var chatMessage = await _dbContext.ChatMessages.FirstOrDefaultAsync(m => m.ChatRoomId == chatRoom.Id);
            Assert.NotNull(chatMessage);
            Assert.That(chatMessage.Content, Is.EqualTo(message.Content));
            Assert.That(chatMessage.SenderId, Is.EqualTo(senderId));
            Assert.That(chatMessage.UserName, Is.EqualTo("senderUserName"));
        }

        [Test]
        public async Task DoesChatRoomExistAsync_ExistingRoom_ReturnsTrue()
        {
            // Arrange
            await _dbContext.ChatRooms.AddAsync(new ChatRoom { Id = 19, SalonId = 19 });
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _chatService.DoesChatRoomExistAsync(19);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task DoesChatRoomExistAsync_NonExistingRoom_ReturnsFalse()
        {
            // Act
            var result = await _chatService.DoesChatRoomExistAsync(93);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetCurrentUserAsync_ReturnsCurrentUser()
        {
            // Arrange
            var user = new User { Id = "user1", UserName = "TestUser" };

            // Mock IHttpContextAccessor and setup HttpContext
            var httpContext = new DefaultHttpContext();
            httpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            }));

            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);

            // Mock UserManager<User> and setup GetUserAsync
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(),
                null!, null!, null!, null!, null!, null!, null!, null!);

            userManagerMock.Setup(u => u.GetUserAsync(httpContext.User))
                .ReturnsAsync(user);
            var _salonService = new SalonService(_dbContext);

            var chatService = new ChatService(_dbContext, _salonService, userManagerMock.Object, httpContextAccessorMock.Object);

            // Act
            var result = await chatService.GetCurrentUserAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(user.Id));
            Assert.That(result.UserName, Is.EqualTo(user.UserName));
        }



        private Mock<UserManager<TUser>> MockUserManager<TUser>() where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            return new Mock<UserManager<TUser>>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
        }
    }
}
