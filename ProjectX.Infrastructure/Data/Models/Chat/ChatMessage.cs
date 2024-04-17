namespace ProjectX.Infrastructure.Data.Models.Chat
{
    /// <summary>
    /// Represents a message within a chat room.
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier of the chat message.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ID of the chat room associated with the message.
        /// </summary>
        public int ChatRoomId { get; set; }

        /// <summary>
        /// Gets or sets the username of the sender of the message.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the sender of the message.
        /// </summary>
        public string SenderId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time when the message was sent.
        /// </summary>
        public DateTime DateAndTime { get; set; }

        // Navigation properties

        /// <summary>
        /// Gets or sets the chat room associated with the message.
        /// </summary>
        public ChatRoom ChatRoom { get; set; } = null!;
    }
}

