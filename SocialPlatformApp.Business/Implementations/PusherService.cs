using Microsoft.EntityFrameworkCore;
using PusherServer;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;

namespace SocialPlatformApp.Business.Implementations
{
    public class PusherService : IPusherService
    {
        private readonly DataContext _context;

        public PusherService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ChatMessageDto>> GetChatHistory(int userId1, int userId2)
        {
            var messages = await _context.ChatMessages
                .Where(cm =>
                    (cm.SenderId == userId1 && cm.ReceiverId == userId2) ||
                    (cm.SenderId == userId2 && cm.ReceiverId == userId1))
                .OrderBy(cm => cm.Timestamp)
                .Select(cm => new ChatMessageDto
                {
                    SenderId = cm.SenderId,
                    ReceiverId = cm.ReceiverId,
                    Content = cm.Content,
                    Timestamp = cm.Timestamp
                })
                .ToListAsync();

            return messages;
        }

        public async Task<ITriggerResult> SendMessage(ChatMessageDto chatMessageDto)
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
                "1856137",
                "7ca0f2746782106acb5f", // Replace with your Pusher key
                "66852e03394ccccd4cd5", // Replace with your Pusher secret
                options);

            // Save the message to the database
            var chatMessage = new ChatMessage
            {
                SenderId = chatMessageDto.SenderId,
                ReceiverId = chatMessageDto.ReceiverId,
                Content = chatMessageDto.Content,
                Timestamp = DateTime.UtcNow
            };

            await _context.ChatMessages.AddAsync(chatMessage);
            await _context.SaveChangesAsync();

            // Generate the private channel name
            var channelName = $"private-chat-{chatMessageDto.SenderId}-{chatMessageDto.ReceiverId}";

            // Get sender and receiver usernames for display
            var sender = await _context.Users.FindAsync(chatMessageDto.SenderId);
            var receiver = await _context.Users.FindAsync(chatMessageDto.ReceiverId);

            // Trigger Pusher event for real-time update
            var result = await pusher.TriggerAsync(
                channelName, // Use the private channel name
                "message",  // Event name
                new
                {
                    message = chatMessageDto.Content,
                    sender = sender?.Username ?? "Unknown", // Username of the sender
                    receiver = receiver?.Username ?? "Unknown", // Username of the receiver
                    timestamp = chatMessage.Timestamp
                });

            return result;
        }
    }
}
