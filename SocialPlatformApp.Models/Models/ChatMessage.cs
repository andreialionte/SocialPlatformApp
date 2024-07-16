using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialPlatformApp.Models.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public int SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User? Sender { get; set; } //current user who sends the message
        public int ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public User? Receiver { get; set; } //other user who recive the message
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
