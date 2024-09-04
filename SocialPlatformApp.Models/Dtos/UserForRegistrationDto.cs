namespace SocialPlatformApp.Models.Dtos
{
    public class UserForRegistrationDto
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        /*        public int UserId { get; set; }*/
    }
}
