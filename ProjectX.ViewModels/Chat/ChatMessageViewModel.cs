namespace ProjectX.ViewModels.Chat
{
    public class ChatMessageViewModel
    {
        public string SenderName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int ChatRoomId { get; set; }
        public string SalonProfilePictureUrl { get; set; } = string.Empty;
    }
}
