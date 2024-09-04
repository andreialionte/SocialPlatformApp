using System.ComponentModel.DataAnnotations;

namespace SocialPlatformApp.Models.Models
{
    public class Auth
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        /*        [ForeignKey("UserId")]*/
        /*        public User? User { get; set; }
                public int UserId { get; set; }*/
    }
}
