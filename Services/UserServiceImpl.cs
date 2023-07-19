using ThreadsFeature.DTO;
using ThreadsFeature.IRepository;
using ThreadsFeature.IServices;
using ThreadsFeature.Models;
using ThreadsFeature.utils;

namespace ThreadsFeature.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly ILogger<ThreadServicesImpl> _logger;
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;
        private readonly HelperService _helperService;

        public UserServiceImpl(ILogger<ThreadServicesImpl> logger, CommentRepository commentRepository, UserRepository userRepository, HelperService helperService)
        {
            _logger = logger;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _helperService = helperService;
        }
        public User CreateUser(UserDTO userDTO)
        {
            try
            {
                User? user = new User();
                user.Name = userDTO.Name;
                _userRepository.CreateUser(user);
                return user;

            }
            catch
            {
                throw new Exception("Error while creating user");
            }
        }

        public User DeleteUser(string id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return null;

            }
            catch
            {
                throw new Exception("Error while deleting user");
            }
        }

        public List<CommentResponseDTO> GetAllReplies(string userId)
        {
            try
            {
                List<CommentResponseDTO> replies = new List<CommentResponseDTO> ();
                foreach(Comment comment in _userRepository.GetUserById(userId).Comments)
                {
                    if (comment.Parent != null) replies.Add(_helperService.ConvertCommentToCommentResponse(comment));
                }
                return replies;
            }
            catch
            {
                throw new Exception("Error while getting user replies");
            }
        }

        public List<CommentResponseDTO> GetAllTweets(string userId)
        {
            try
            {
                List<CommentResponseDTO> replies = new List<CommentResponseDTO>();
                foreach (Comment comment in _userRepository.GetUserById(userId).Comments)
                {
                    if (comment.Parent == null) replies.Add(_helperService.ConvertCommentToCommentResponse(comment));
                }
                return replies;
            }
            catch
            {
                throw new Exception("Error while getting user tweets");
            }
        }

        public User GetUser(string id)
        {
            try
            {
                return _userRepository.GetUserById(id);

            }
            catch
            {
                throw new Exception("Error while getting user");
            }
        }

        public User UpdateUser(UserDTO userDTO, string id)
        {
            try
            {
                User user = new User();
                user.Name = userDTO.Name;
                return _userRepository.UpdateUser(user, id);

            }
            catch
            {
                throw new Exception("Error while updating user");
            }
        }
    }
}
