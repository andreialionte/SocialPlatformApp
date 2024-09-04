using Microsoft.AspNetCore.Mvc;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : ControllerBase
    {
        private readonly IChatMessageService _chatMessageService;

        public ChatMessagesController(IChatMessageService chatMessageService)
        {
            _chatMessageService = chatMessageService;
        }
        //make all ChatMessageDto
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] ChatMessage message)
        {
            if (message == null)
            {
                return BadRequest("Message cannot be null.");
            }

            try
            {
                // Assuming channelName can be derived from sender or receiver information
                string channelName = $"channel-{message.SenderId}-{message.ReceiverId}";

                await _chatMessageService.SendMessageAsync(channelName, message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/chatmessages/{id}
        [HttpGet("GetMessageById/{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            try
            {
                var message = await _chatMessageService.GetMessageByIdAsync(id);
                if (message == null)
                {
                    return NotFound();
                }

                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE api/chatmessages/{id}
        [HttpDelete("DeleteMessage/{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            try
            {
                await _chatMessageService.DeleteMessageAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/chatmessages/channel/{channelName}
        [HttpGet("channel/{channelName}")]
        public async Task<IActionResult> GetMessagesByChannel(string channelName)
        {
            try
            {
                var messages = await _chatMessageService.GetMessagesByChannelAsync(channelName);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/chatmessages/subscribe
        [HttpPost("subscribe")]
        public IActionResult SubscribeToChannel([FromBody] string channelName)
        {
            try
            {
                _chatMessageService.SubscribeToChannel(channelName, message =>
                {
                    // Handle incoming message
                    // This part should be implemented in a way that fits your app's architecture
                    // For example, you might broadcast the message to all connected clients
                });

                return Ok("Subscribed to channel");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/chatmessages/unsubscribe
        [HttpPost("unsubscribe")]
        public IActionResult UnsubscribeFromChannel([FromBody] string channelName)
        {
            try
            {
                _chatMessageService.UnsubscribeFromChannel(channelName);
                return Ok("Unsubscribed from channel");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
