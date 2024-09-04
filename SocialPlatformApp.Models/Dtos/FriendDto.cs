using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Models.Dtos
{
    public class FriendDto
    {
        public int UserId { get; set; }
        public User? User { get; set; } //curent user
        public int FriendId { get; set; }
        public User? FriendUser { get; set; } //what user we want to add check if that user exist and send friend req
        public DateTime FriendsFrom { get; set; } //when they got friends
    }
}
