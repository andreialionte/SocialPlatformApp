using IO.Ably;
using Newtonsoft.Json; // or System.Text.Json if preferred
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;

namespace SocialPlatformApp.Business.Implementations;

public class AblyChatService
{
    private readonly IRealtimeClient _realtimeClient;

    public AblyChatService(string apiKey)
    {
        _realtimeClient = new AblyRealtime(apiKey);
    }

    // Publish a message to a channel
    public async Task SendMessageAsync(string channelName, ChatMessage message)
    {
        var channel = _realtimeClient.Channels.Get(channelName);
        await channel.PublishAsync("newMessage", new ChatMessageDto
        {
            Id = message.Id,
            SenderId = message.SenderId,
            ReceiverId = message.ReceiverId,
            Content = message.Content,
            Timestamp = message.Timestamp
        });
    }

    // Subscribe to a channel and handle incoming messages
    public void SubscribeToChannel(string channelName, Action<ChatMessage> onMessageReceived)
    {
        var channel = _realtimeClient.Channels.Get(channelName);
        channel.Subscribe("newMessage", message =>
        {
            var chatMessageDto = JsonConvert.DeserializeObject<ChatMessageDto>(message.Data.ToString());

            if (chatMessageDto != null)
            {
                var chatMessage = new ChatMessage
                {
                    Id = chatMessageDto.Id,
                    SenderId = chatMessageDto.SenderId,
                    ReceiverId = chatMessageDto.ReceiverId,
                    Content = chatMessageDto.Content,
                    Timestamp = chatMessageDto.Timestamp
                };

                onMessageReceived(chatMessage);
            }
        });
    }

    // Unsubscribe from a channel
    public void UnsubscribeFromChannel(string channelName)
    {
        var channel = _realtimeClient.Channels.Get(channelName);
        channel.Unsubscribe();
    }
}
