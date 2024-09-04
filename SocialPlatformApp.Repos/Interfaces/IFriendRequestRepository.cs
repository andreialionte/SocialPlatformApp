using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IFriendRequestRepository
    {
        Task<FriendRequest> SendFriendReq(int id, string usernameToAdd);
        Task<List<FriendRequest>> ReciveAllFriendReq(int id);
        Task<FriendRequest> AcceptFriendReq(int id, string usernameToAccept);
        Task<FriendRequest> RejectFriendReq(int id, string usernameToReject);
    }
}
