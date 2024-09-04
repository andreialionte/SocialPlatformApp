using Microsoft.AspNetCore.Mvc;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendService _friendService;
        public FriendsController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        [HttpGet("GetFriends")]
        public async Task<IActionResult> GetFriends()
        {
            List<Friend> friends = await _friendService.GetFriends();
            return Ok(friends);
        }

        [HttpGet("GetFriend/{id}")]
        public async Task<ActionResult<List<Friend>>> GetFriend(int id)
        {
            var friend = await _friendService.GetFriendById(id);
            return Ok(friend);
        }


        [HttpGet("GetFriendByUsername/{username}")]
        public async Task<ActionResult<List<Friend>>> GetFriend(string username)
        {
            return Ok();
        }


        [HttpPost("CreateFriends")]
        public async Task<IActionResult> CreateFriends(FriendDto friendDto)
        {
            Friend friend = await _friendService.CreateFriendshipBetween2Users(friendDto);
            return Ok(friend);
        }

        [HttpDelete("DeleteFriends/{id}/{friendId}")]
        public async Task<IActionResult> DeleteFriends(int id, int friendId)
        {
            var friends = await _friendService.DeleteFriendshipBetween2Users(id, friendId);
            return Ok(friends);
        }
    }
}
