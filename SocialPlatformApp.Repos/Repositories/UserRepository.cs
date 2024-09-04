using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Repos.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) : base(context)
        {
            _context = context;

        }


        public async Task<User> Create(UserDto entityDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == entityDto.Username);
            if (user != null)
            {
                throw new InvalidOperationException("The username is already in use!");
            }
            entityDto.Email = user.Email;
            entityDto.FirstName = user.FirstName;
            entityDto.LastName = user.LastName;
            entityDto.Username = user.Username;
            entityDto.Bio = user.Bio;
            user.CreatedAt = DateTime.UtcNow;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task<User> Delete(int entityId)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == entityId);
            if (entity == null)
            {
                throw new InvalidOperationException("The user was not found!");
            }
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetById(int entityId)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == entityId);
        }

        public async Task<User> Update(int entityId, UserDto entityDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == entityId);
            if (user == null)
            {
                throw new InvalidOperationException("The user was not found!");
            }
            entityDto.Email = user.Email;
            entityDto.FirstName = user.FirstName;
            entityDto.LastName = user.LastName;
            entityDto.Username = user.Username;
            entityDto.Bio = user.Bio;
            user.CreatedAt = DateTime.UtcNow;


            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }


        public async Task<List<User>> GetUsersByUserName(string userName)
        {
            var friendships = await _context.Users.AsNoTracking().Where(f => f.Username == userName).ToListAsync();
            if (friendships == null)
            {
                throw new Exception("The user does not exist");
            }
            return friendships;
        }
    }
}
