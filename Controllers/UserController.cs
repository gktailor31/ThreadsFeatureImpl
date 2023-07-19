using Microsoft.AspNetCore.Mvc;
using ThreadsFeature.DTO;
using ThreadsFeature.IServices;
using ThreadsFeature.Models;
using ThreadsFeature.utils;

namespace ThreadsFeature.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ILogger<ThreadController> _logger;
        private readonly UserService _userService;
        private readonly HelperService _helperService;

        public UserController(ILogger<ThreadController> logger, UserService userService, HelperService helperService)
        {
            _logger = logger;
            _userService = userService;
            _helperService = helperService;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserDTO userDTO)
        {
            return Ok(_userService.CreateUser(userDTO));
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUser(string userId)
        {
            return Ok(_userService.GetUser(userId));
        }

        [HttpDelete("{userId}")]
        public ActionResult<User> DeleteUser(string userId)
        {
            return Ok(_userService.DeleteUser(userId));
        }

        [HttpPut("{userId}")]
        public ActionResult<User> UpdateUser([FromBody]UserDTO user, string userId)
        {
            return Ok(_userService.UpdateUser(user, userId));
        }

        [HttpGet("{userId}/tweets")]
        public ActionResult<List<CommentResponseDTO>> GetAllTweets(string userId)
        {
            return Ok(_userService.GetAllTweets(userId));
        }

        [HttpGet("{userId}/replies")]
        public ActionResult<List<CommentResponseDTO>> GetAllReplies(string userId)
        {
            return Ok(_userService.GetAllReplies(userId));
        }
    }
}
