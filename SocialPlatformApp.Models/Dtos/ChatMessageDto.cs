using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Models.Dtos
{
    public class ChatMessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User? Sender { get; set; } //current user who sends the message
        public int ReceiverId { get; set; }
        public User? Receiver { get; set; } //other user who recive the message
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string? Channel { get; set; } // new 
    }
}
