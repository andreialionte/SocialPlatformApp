using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Business.Implementations
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly AblyChatService _ablyChatService;

        public ChatMessageService(IChatMessageRepository chatMessageRepository, AblyChatService ablyChatService)
        {
            _chatMessageRepository = chatMessageRepository;
            _ablyChatService = ablyChatService;
        }

        public async Task SendMessageAsync(string channelName, ChatMessage message)
        {
            // Save the message to the database
            await _chatMessageRepository.AddMessageAsync(message);

            // Publish the message to Ably
            await _ablyChatService.SendMessageAsync(channelName, message);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _chatMessageRepository.DeleteMessageAsync(id);
        }

        public async Task<ChatMessage> GetMessageByIdAsync(int id)
        {
            return await _chatMessageRepository.GetMessageByIdAsync(id);
        }

        public async Task<List<ChatMessage>> GetMessagesByChannelAsync(string channel)
        {
            return await _chatMessageRepository.GetMessagesByChannelAsync(channel);
        }

        public void SubscribeToChannel(string channelName, Action<ChatMessage> onMessageReceived)
        {
            _ablyChatService.SubscribeToChannel(channelName, onMessageReceived);
        }

        public void UnsubscribeFromChannel(string channelName)
        {
            _ablyChatService.UnsubscribeFromChannel(channelName);
        }
    }
}
