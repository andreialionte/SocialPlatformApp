using System.ComponentModel.DataAnnotations;

namespace SocialPlatformApp.Models.Dtos
{
    public class MessageDto
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
