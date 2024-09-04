using Konscious.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.DataLayer;
using SocialPlatformApp.Repos.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SocialPlatformApp.Repos.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly ITokenRepository _tokenService;

        public AuthRepository(DataContext context, ITokenRepository tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<object> LoginRepo(UserForLoginDto user)
        {
            var userByEmail = await _context.Auths
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userByEmail == null)
            {
                throw new Exception("The user doesn't exist");
            }

            var isPasswordValid = VerifyPassword(user.Password, userByEmail.PasswordHash,
                userByEmail.PasswordSalt);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid password");
            }

            var token = _tokenService.JWTService(userByEmail.Email, userByEmail.Id);

            return new { Token = token, User = userByEmail, Message = "Login Success!" };
        }

        public async Task<object> RegisterRepo(UserForRegistrationDto user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                throw new Exception("Passwords must match!");
            }

            var checkIfUserNameExists = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.UserName);
            var checkIfEmailExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (checkIfUserNameExists != null || checkIfEmailExists != null)
            {
                throw new Exception("The user or email already exists!");
            }

            var (salt, hashedPassword) = HashPassword(user.Password);

            var newUser = new User
            {
                Username = user.UserName,
                Email = user.Email,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
            };

            var auth = new Auth
            {
                Email = user.Email,
                PasswordSalt = salt,
                PasswordHash = hashedPassword,
            };

            _context.Auths.Add(auth);
            await _context.SaveChangesAsync();

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new { User = newUser, Auth = auth };
        }

        private (byte[] salt, byte[] hashedPassword) HashPassword(string password)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                // Argon2.
                hasher.Salt = GenerateSalt();
                hasher.DegreeOfParallelism = 8;
                hasher.MemorySize = 65536;
                hasher.Iterations = 4;

                var hashedPassword = hasher.GetBytes(32);

                return (hasher.Salt, hashedPassword);
            }
        }

        private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hasher = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                hasher.Salt = storedSalt;
                hasher.DegreeOfParallelism = 8;
                hasher.MemorySize = 65536;
                hasher.Iterations = 4;

                var computedHash = hasher.GetBytes(32);

                return CryptographicOperations.FixedTimeEquals(storedHash, computedHash);
            }
        }

        private byte[] GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) //i can generate too with bcrypt the salt
                                                             //bcrypt much better to use
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        // add methods for forgot password and reset password
        // for forgot password, you need to receive an email
        // for reset password, you need to set the new password
    }
}
