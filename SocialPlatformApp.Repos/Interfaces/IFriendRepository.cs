using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IFriendRepository
    {
        Task<List<Friend>> GetFriendsByUserId(int userId);
        Task<List<Friend>> GetAll();
        Task<Friend> Create(FriendDto entity);
        Task<Friend> Update(int id, FriendDto entity);
        /*        Task Delete(int id);*/
        Task<Friend> Delete(int id, int friendid);
        /*        Task<List<Friend>> GetFriendsByUserName(string userName);*/
        /*Task<Friend> SendFriendReq(int id, FriendDto entity);*/ //it need to send to someone an frien req and it should display pending
        /*        Task<Friend> ReciveAllFriendReq(int id);
                Task<Friend> AcceptFriendReq(int id);
                Task<Friend> RejectFriendReq(int id);*/
    }
}
