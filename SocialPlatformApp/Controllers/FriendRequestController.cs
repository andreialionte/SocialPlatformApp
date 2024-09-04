using Microsoft.AspNetCore.Mvc;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendRequestController : ControllerBase
    {
        private readonly IFriendRequestService _friendRequestService;

        public FriendRequestController(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        [HttpGet("RetriveAllFriendRequests")]
        public async Task<ActionResult<List<FriendRequest>>> RetriveAllFriendRequests(int id)
        {
            var friend = await _friendRequestService.RetriveAllFrienReqByUserId(id);
            return Ok(friend);
        }

        [HttpPost("SendFriendRequest")]
        public async Task<ActionResult<FriendRequest>> SendFriendRequest(int id, string usernameToAdd)
        {
            var friend = await _friendRequestService.SendFriendReqByUserIdAndFriendId(id, usernameToAdd);
            return Ok(new { Message = "Friend Request was sent succesfully!", Friend = friend });
        }

        [HttpPost("AcceptFriendRequest")]
        public async Task<IActionResult> AcceptFriendRequest([FromQuery] int id, [FromQuery] string usernameToAccept)
        {
            try
            {
                var result = await _friendRequestService.AcceptFriendReqByUserId(id, usernameToAccept);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("RejectFriendRequest")]
        public async Task<ActionResult<FriendRequest>> RejectFriendRequest(int id, string usernameToReject)
        {
            var friend = await _friendRequestService.RejectFriendReqByUserId(id, usernameToReject);
            return Ok(friend);
        }
    }
}
