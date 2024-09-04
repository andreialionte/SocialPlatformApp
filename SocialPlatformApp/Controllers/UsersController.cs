using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformApp.Business.Interfaces;
using SocialPlatformApp.Models.Dtos;

namespace SocialPlatformApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("GetUser/{userid}")]
        public async Task<IActionResult> GetUser(int userid)
        {
            var user = await _userService.GetUser(userid);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUsers/{username}")]
        public async Task<IActionResult> GetUsers(string username)
        {
            var users = await _userService.GetUserByTheUserName(username);
            return Ok(users);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {

            if (userDto == null)
            {
                return BadRequest("User data is null");
            }

            var createdUser = await _userService.CreateUser(userDto);

            return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);

        }

        [HttpPut("UpdateUser/{userid}")]
        public async Task<IActionResult> UpdateUser(int userid, UserDto userDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("DeleteUser/{userid}")]
        public async Task<IActionResult> DeleteUser(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
