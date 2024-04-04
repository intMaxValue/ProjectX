namespace ProjectX.ViewModels.Chat
{
    public class SalonChatViewModel
    {
        public int SalonId { get; set; }
        public string SalonName { get; set; } = string.Empty;
        public string SalonProfilePictureUrl { get; set; } = string.Empty;
        public List<ChatMessageViewModel> Messages { get; set; } = new List<ChatMessageViewModel>();
        public string NewMessage { get; set; } = string.Empty;
    }
}
