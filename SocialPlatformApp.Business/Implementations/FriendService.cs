using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Business.Implementations
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepo;

        public FriendService(IFriendRepository friendRepo)
        {
            _friendRepo = friendRepo;
        }


        public async Task<Friend> CreateFriendshipBetween2Users(FriendDto friendDto)
        {
            var newfriend = await _friendRepo.Create(friendDto);
            return newfriend;
        }

        public async Task<Friend> DeleteFriendshipBetween2Users(int Id, int friendId)
        {
            var friend = await _friendRepo.Delete(Id, friendId);
            return friend;
        }

        public async Task<List<Friend>> GetFriendById(int id)
        {
            return await _friendRepo.GetFriendsByUserId(id);
        }

        public Task<List<Friend>> GetFriends()
        {
            return _friendRepo.GetAll();
        }
    }
}
