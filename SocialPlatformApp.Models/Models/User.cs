using System.ComponentModel.DataAnnotations;

namespace SocialPlatformApp.Models.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        /*[MaxLength(50)]*/
        [Required(ErrorMessage = "Please add an username")]
        public string? Username { get; set; }
        /*[MaxLength(50)]*/
        public string? FirstName { get; set; }
        /*[MaxLength(50)]*/
        public string? LastName { get; set; }
        /*        [MaxLength(100)]*/
        public string? Email { get; set; }
        /*        [MaxLength(50)]*/
        public string? Bio { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public ICollection<Friend>? Friends { get; set; }
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Like>? Like { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<ChatMessage>? SentMessages { get; set; }
        public ICollection<ChatMessage>? ReceivedMessages { get; set; }
    }
}
