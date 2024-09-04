namespace SocialPlatformApp.Models.Dtos
{
    public class UserDto
    {
        /*        public int Id { get; set; }*/
        /*[MaxLength(50)]*/
        /*        [Required(ErrorMessage = "Please add an username")]*/
        public string? Username { get; set; }
        /*[MaxLength(50)]*/
        public string? FirstName { get; set; }
        /*[MaxLength(50)]*/
        public string? LastName { get; set; }
        /*        [MaxLength(100)]*/
        public string? Email { get; set; }
        /*        [MaxLength(50)]*/
        public string? Bio { get; set; }
    }
}
