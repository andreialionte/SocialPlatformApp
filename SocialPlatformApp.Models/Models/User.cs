using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime LastUpdatedAt { get; set; }
        [JsonIgnore]

        public ICollection<Friend>? Friends { get; set; }
        [JsonIgnore]
        public ICollection<Friend>? FriendsOf { get; set; }
        [JsonIgnore]

        public ICollection<Post>? Posts { get; set; }
        [JsonIgnore]
        public ICollection<Like>? Like { get; set; }
        [JsonIgnore]
        public ICollection<Comment>? Comments { get; set; }
        [JsonIgnore]
        public ICollection<ChatMessage>? SentMessages { get; set; }
        [JsonIgnore]
        public ICollection<ChatMessage>? ReceivedMessages { get; set; }
        [JsonIgnore]
        public ICollection<FriendRequest>? FriendRequests { get; set; }
        [JsonIgnore]
        public ICollection<FriendRequest>? ReceivedFriendRequests { get; set; }
        /*        [ForeignKey("AuthId")]*/
        /*        public Auth? Auth { get; set; }
                public int AuthId { get; set; }*/
    }
}
