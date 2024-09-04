using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IFriendRequestService
    {
        Task<List<FriendRequest>> RetriveAllFrienReqByUserId(int id);
        Task<FriendRequest> AcceptFriendReqByUserId(int id, string usernameToAccept);
        Task<FriendRequest> RejectFriendReqByUserId(int id, string usernameToReject);
        Task<FriendRequest> SendFriendReqByUserIdAndFriendId(int id, string usernameToAdd);
    }
}
