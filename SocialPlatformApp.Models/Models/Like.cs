using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialPlatformApp.Models.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? Post { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
