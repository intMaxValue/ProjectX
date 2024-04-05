namespace ProjectX.Infrastructure.Data.Models.Chat
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string SenderId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }

        // Navigation properties
        public ChatRoom ChatRoom { get; set; } = null!;
    }
}

