using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialPlatformApp.Models.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
