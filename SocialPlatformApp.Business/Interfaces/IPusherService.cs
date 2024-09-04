using PusherServer;
using SocialPlatformApp.Models.Dtos;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IPusherService
    {
        Task<ITriggerResult> SendMessage(ChatMessageDto chatMessageDto);
        Task<List<ChatMessageDto>> GetChatHistory(int userId1, int userId2);
    }
}
