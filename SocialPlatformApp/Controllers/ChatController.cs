using Microsoft.AspNetCore.Mvc;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;

namespace SocialPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IPusherService _pusherService;

        public ChatController(IPusherService pusherService)
        {
            _pusherService = pusherService;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessageDto chatMessageDto)
        {
            var result = await _pusherService.SendMessage(chatMessageDto);
            return Ok(result);
        }

        [HttpGet("GetHistory")]
        public async Task<IActionResult> GetChatHistory([FromQuery] int userId1, [FromQuery] int userId2)
        {
            var messages = await _pusherService.GetChatHistory(userId1, userId2);
            return Ok(messages);
        } //those we need to add in chatapp angular to test if it woorks properly.
    }
}
