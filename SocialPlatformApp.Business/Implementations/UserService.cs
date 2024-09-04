using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;
using SocialPlatformApp.Models.Models;
using SocialPlatformApp.Repos.Interfaces;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(UserDto userDto)
    {
        var userEntity = new User
        {
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Username = userDto.Username,
            Bio = userDto.Bio,
            CreatedAt = DateTime.UtcNow
        };

        var createdUser = await _userRepository.Create(userEntity);
        return createdUser;

    }

    public async Task DeleteUser(int userId)
    {
        await _userRepository.Delete(userId);
    }

    public async Task<User> GetUser(int userId)
    {
        var user = await _userRepository.GetById(userId);
        if (user == null)
        {
            return null;
        }
        return user;
    }

    public async Task<List<User>> GetUserByTheUserName(string userName)
    {
        var user = await _userRepository.GetUsersByUserName(userName);
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetAll();

        return users;
    }

    public async Task<User> UpdateUser(int userId, UserDto userDto)
    {
        var userEntity = await _userRepository.GetById(userId);
        if (userEntity == null)
        {
            throw new InvalidOperationException("User not found!");
        }

        var updatedUser = await _userRepository.Update(userId, userEntity);
        return updatedUser;
    }
}
