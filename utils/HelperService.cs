using Newtonsoft.Json;
using ThreadsFeature.DTO;
using ThreadsFeature.IRepository;
using ThreadsFeature.Models;

namespace ThreadsFeature.utils
{
    public class HelperService
    {
        private ILogger<HelperService> _logger;
        private readonly CommentRepository _commentRepository;
        private readonly LikeRepository _likeRepository;
        private readonly UserRepository _userRepository;

        public HelperService(ILogger<HelperService> logger, CommentRepository commentRepository, LikeRepository likeRepository, UserRepository userRepository)
        {
            _logger = logger;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
            _userRepository = userRepository;
        }

        public CommentResponseDTO ConvertCommentToCommentResponse(Comment comment)
        {

            CommentResponseDTO commentResponseDTO = new CommentResponseDTO();
            commentResponseDTO.Attachment = comment.Attachment;
            commentResponseDTO.Content = comment.Content;
            commentResponseDTO.Replies = comment.Child.Count;
            commentResponseDTO.Likes = comment.Likes.Count;
            commentResponseDTO.Id = comment.CommentId;
            commentResponseDTO.CreatorName = comment.Creator.Name;
            return commentResponseDTO;
        }

        public UserResponseDTO UserToUserResponse(User user)
        {
            UserResponseDTO userResponseDTO = new UserResponseDTO();
            userResponseDTO.Name = user.Name;
            userResponseDTO.UserId = user.UserId;
            return userResponseDTO;
        }
    }
}
