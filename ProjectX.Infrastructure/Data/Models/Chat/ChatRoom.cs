namespace ProjectX.Infrastructure.Data.Models.Chat
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int SalonId { get; set; }
        public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

        // Navigation properties
        public Salon Salon { get; set; } = null!;
    }
}
