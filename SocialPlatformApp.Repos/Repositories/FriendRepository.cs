using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Repos.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataContext _context;
        public FriendRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Friend> Create(FriendDto entity)
        {
            var existingFriendship1 = await _context.Friends
                .FirstOrDefaultAsync(f => f.UserId == entity.UserId && f.FriendId == entity.FriendId);

            var existingFriendship2 = await _context.Friends
                .FirstOrDefaultAsync(f => f.UserId == entity.FriendId && f.FriendId == entity.UserId);

            if (existingFriendship1 != null || existingFriendship2 != null)
            {
                throw new InvalidOperationException("You are already friends!");
            }

            // Add new friend relationship (UserId -> FriendId)
            var newFriendship1 = new Friend
            {
                UserId = entity.UserId,
                FriendId = entity.FriendId,
                FriendsFrom = DateTime.UtcNow
            };

            await _context.Friends.AddAsync(newFriendship1);

            var newFriendship2 = new Friend
            {
                UserId = entity.FriendId,
                FriendId = entity.UserId,
                FriendsFrom = DateTime.UtcNow
            };

            await _context.Friends.AddAsync(newFriendship2);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return newFriendship1;
        }


        public async Task<Friend> Delete(int id, int friendid)
        {
            var friendship1 = await _context.Friends
       .FirstOrDefaultAsync(f => f.UserId == id && f.FriendId == friendid);

            var friendship2 = await _context.Friends
                .FirstOrDefaultAsync(f => f.UserId == friendid && f.FriendId == id);
            if (friendship1 == null && friendship2 == null)
            {
                throw new Exception("The friendship dosent exist");
            }

            _context.Friends.Remove(friendship2);
            _context.Friends.Remove(friendship1);
            await _context.SaveChangesAsync();

            return friendship1;
        }

        public async Task<List<Friend>> GetAll()
        {
            var friendships = await _context.Friends.ToListAsync();
            return friendships;
        }

        public async Task<List<Friend>> GetFriendsByUserId(int userId)
        {
            var friends = await _context.Friends
                .Where(f => f.UserId == userId || f.FriendId == userId)
                .Include(f => f.FriendUser)
                .Include(f => f.User)
                .ToListAsync();

            return friends;
        }






        public Task<Friend> Update(int id, FriendDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
