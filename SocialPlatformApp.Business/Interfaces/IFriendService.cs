using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IFriendService
    {
        Task<List<Friend>> GetFriends();
        Task<List<Friend>> GetFriendById(int id);
        Task<Friend> CreateFriendshipBetween2Users(FriendDto friendDto);
        Task<Friend> DeleteFriendshipBetween2Users(int Id, int friendId);

    }
}
