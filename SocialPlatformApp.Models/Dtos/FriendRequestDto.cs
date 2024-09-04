using SocialPlatformApp.Models.Enums;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Models.Dtos
{
    public class FriendRequestDto
    {
        public int SenderId { get; set; }
        public User? Sender { get; set; }

        public int RecipientId { get; set; }
        public User? Recipient { get; set; }
        /*
                public DateTime RequestedAt { get; set; }
                public DateTime? RespondedAt { get; set; }*/

        public RequestStatus? Status { get; set; }
    }
}
