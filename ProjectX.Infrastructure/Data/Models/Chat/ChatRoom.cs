namespace ProjectX.Infrastructure.Data.Models.Chat
{
    /// <summary>
    /// Represents a chat room associated with a salon.
    /// </summary>
    public class ChatRoom
    {
        /// <summary>
        /// Gets or sets the unique identifier of the chat room.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user associated with the chat room.
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the salon associated with the chat room.
        /// </summary>
        public int SalonId { get; set; }

        /// <summary>
        /// Gets or sets the collection of chat messages in the chat room.
        /// </summary>
        public ICollection<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

        // Navigation properties

        /// <summary>
        /// Gets or sets the salon associated with the chat room.
        /// </summary>
        public Salon Salon { get; set; } = null!;
    }
}
