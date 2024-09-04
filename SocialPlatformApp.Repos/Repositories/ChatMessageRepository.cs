using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Repos.Repositories
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly DataContext _context;

        public ChatMessageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(ChatMessage message)
        {
            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var message = await _context.ChatMessages.FindAsync(id);
            if (message != null)
            {
                _context.ChatMessages.Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ChatMessage> GetMessageByIdAsync(int id)
        {
            return await _context.ChatMessages.FindAsync(id);
        }

        public async Task<List<ChatMessage>> GetMessagesByChannelAsync(string channel)
        {
            // Assuming `Channel` is a field in `ChatMessage`
            return await _context.ChatMessages
                .Where(m => m.Channel == channel)
                .ToListAsync();
        }

        public async Task UpdateMessageAsync(ChatMessage message)
        {
            _context.ChatMessages.Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
