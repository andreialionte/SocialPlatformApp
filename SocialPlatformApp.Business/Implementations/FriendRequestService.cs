using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Business.Implementations
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestRepository _friendRepo;
        public FriendRequestService(IFriendRequestRepository friendRepo)
        {
            _friendRepo = friendRepo;
        }

        public async Task<FriendRequest> SendFriendReqByUserIdAndFriendId(int id, string usernameToAdd)
        {
            var friend = await _friendRepo.SendFriendReq(id, usernameToAdd);
            return friend;
        }

        public async Task<FriendRequest> AcceptFriendReqByUserId(int id, string usernameToAccept)
        {
            var friend = await _friendRepo.AcceptFriendReq(id, usernameToAccept);
            return friend;
        }

        public async Task<FriendRequest> RejectFriendReqByUserId(int id, string usernameToReject)
        {
            var friend = await _friendRepo.RejectFriendReq(id, usernameToReject);
            return friend;
        }

        public async Task<List<FriendRequest>> RetriveAllFrienReqByUserId(int id)
        {
            var friend = await _friendRepo.ReciveAllFriendReq(id);
            return friend;
        }

    }
}
