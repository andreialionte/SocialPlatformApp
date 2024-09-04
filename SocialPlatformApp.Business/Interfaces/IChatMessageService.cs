using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Business.Interfaces
{
    public interface IChatMessageService
    {
        Task SendMessageAsync(string channelName, ChatMessage message);
        Task DeleteMessageAsync(int id);
        Task<ChatMessage> GetMessageByIdAsync(int id);
        Task<List<ChatMessage>> GetMessagesByChannelAsync(string channel);
        void SubscribeToChannel(string channelName, Action<ChatMessage> onMessageReceived);
        void UnsubscribeFromChannel(string channelName);
    }
}
