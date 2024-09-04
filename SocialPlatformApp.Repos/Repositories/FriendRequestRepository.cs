using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Enums;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;

namespace SocialPlatformApp.Repos.Repositories
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly DataContext _context;

        public FriendRequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<FriendRequest> AcceptFriendReq(int id, string usernameToAccept)
        {
            var userToAccept = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == usernameToAccept);

            if (userToAccept == null)
            {
                throw new Exception("The user with the given username does not exist");
            }

            var existingFriendRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(fr => (fr.SenderId == id && fr.RecipientId == userToAccept.Id) ||
                                           (fr.SenderId == userToAccept.Id && fr.RecipientId == id));

            if (existingFriendRequest == null)
            {
                throw new Exception("The friend request was not found");
            }

            existingFriendRequest.Status = RequestStatus.Accepted;
            existingFriendRequest.RespondedAt = DateTime.UtcNow;
            _context.FriendRequests.Update(existingFriendRequest);

            var newFriendship1 = new Friend
            {
                UserId = id,
                FriendId = userToAccept.Id,
                FriendsFrom = DateTime.UtcNow
            };

            var newFriendship2 = new Friend
            {
                UserId = userToAccept.Id,
                FriendId = id,
                FriendsFrom = DateTime.UtcNow
            };

            /*            Console.WriteLine($"Creating friendship from UserId {id} to FriendId {userToAccept.Id}");
                        Console.WriteLine($"Creating friendship from UserId {userToAccept.Id} to FriendId {id}");*/

            await _context.Friends.AddRangeAsync(newFriendship1, newFriendship2);
            await _context.SaveChangesAsync();

            return existingFriendRequest;
        }

        public async Task<List<FriendRequest>> ReciveAllFriendReq(int id)
        {
            var existingFriendReq = await _context.FriendRequests
                .Where(fr => fr.RecipientId == id && fr.Status == RequestStatus.Pending)
                .ToListAsync();

            return existingFriendReq;
        }

        public async Task<FriendRequest> RejectFriendReq(int id, string usernameToReject)
        {
            var userToReject = await _context.Users.FirstOrDefaultAsync(u => u.Username == usernameToReject);

            if (userToReject == null)
            {
                throw new Exception("The user with the given username does not exist");
            }

            var existingFriendRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(fr => (fr.SenderId == id && fr.RecipientId == userToReject.Id) ||
                                           (fr.SenderId == userToReject.Id && fr.RecipientId == id));

            if (existingFriendRequest == null)
            {
                throw new Exception("The friend request was not found");
            }

            existingFriendRequest.Status = RequestStatus.Rejected;
            existingFriendRequest.RespondedAt = DateTime.UtcNow;

            _context.FriendRequests.Update(existingFriendRequest);
            await _context.SaveChangesAsync();

            return existingFriendRequest;
        }

        public async Task<FriendRequest> SendFriendReq(int id, string usernameToAdd)
        {
            // check if the user is trying to send a friend request to themselves
            var userSendingRequest = await _context.Users.FindAsync(id);
            if (userSendingRequest != null && userSendingRequest.Username.Equals(usernameToAdd, StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("You cannot send a friend request to yourself.");
            }

            var userToAdd = await _context.Users.FirstOrDefaultAsync(u => u.Username == usernameToAdd);
            if (userToAdd == null)
            {
                throw new Exception("The user with the given username does not exist.");
            }

            // check if users are already friends
            var existingFriendship = await _context.Friends
                .AnyAsync(f => (f.UserId == id && f.FriendId == userToAdd.Id) ||
                               (f.UserId == userToAdd.Id && f.FriendId == id));
            if (existingFriendship)
            {
                throw new Exception("The users are already friends!");
            }

            // check if there is already a pending friend request
            var existingFriendRequest = await _context.FriendRequests
                .FirstOrDefaultAsync(fr => (fr.SenderId == id && fr.RecipientId == userToAdd.Id) ||
                                            (fr.SenderId == userToAdd.Id && fr.RecipientId == id));

            if (existingFriendRequest != null)
            {
                if (existingFriendRequest.Status == RequestStatus.Pending)
                {
                    throw new Exception($"A pending friend request already exists between user {id} and user {userToAdd.Id}. Please accept or reject it before sending a new request.");
                }

                // if the previous request was rejected, remove the rejected request and proceed with sending a new one
                if (existingFriendRequest.Status == RequestStatus.Rejected)
                {
                    _context.FriendRequests.Remove(existingFriendRequest);
                    await _context.SaveChangesAsync();
                }
            }

            // create and add a new friend request
            var friendReq = new FriendRequest()
            {
                SenderId = id,
                RecipientId = userToAdd.Id,
                RequestedAt = DateTime.UtcNow,
                Status = RequestStatus.Pending
            };

            await _context.FriendRequests.AddAsync(friendReq);
            await _context.SaveChangesAsync();

            return friendReq;
        }




    }
}
