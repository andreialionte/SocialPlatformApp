using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Repos.Interfaces
{
    public interface IChatMessageRepository
    {
        Task AddMessageAsync(ChatMessage message);
        Task<List<ChatMessage>> GetMessagesByChannelAsync(string channel);
        Task<ChatMessage> GetMessageByIdAsync(int id);
        Task UpdateMessageAsync(ChatMessage message);
        Task DeleteMessageAsync(int id);
    }
}
