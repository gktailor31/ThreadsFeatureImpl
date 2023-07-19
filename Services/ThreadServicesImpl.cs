using ThreadsFeature.DTO;
using ThreadsFeature.IRepository;
using ThreadsFeature.IServices;
using ThreadsFeature.Models;
using ThreadsFeature.utils;

namespace ThreadsFeature.Services
{
    public class ThreadServicesImpl : ThreadService
    {
        private readonly ILogger<ThreadServicesImpl> _logger;
        private readonly CommentRepository _commentRepository;
        private readonly UserRepository _userRepository;
        private readonly LikeRepository _likeRepository;
        private readonly HelperService _helperService;


        public ThreadServicesImpl(ILogger<ThreadServicesImpl> logger, CommentRepository commentRepository, UserRepository userRepository, LikeRepository likeRepository, HelperService helperService)
        {
            _logger = logger;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
            _likeRepository = likeRepository;
            _helperService = helperService;
        }
        public Comment CreateComment(CommentDTO commentDTO)
        {
            try
            {
                Comment comment = new Comment();
                comment.Attachment = commentDTO.Attachment;
                comment.Content = commentDTO.Content;
                comment.Parent = commentDTO.ParentCommentId != null ? _commentRepository.GetComment(commentDTO.ParentCommentId) : null;
                comment.CreaterId = commentDTO.UserId;
                comment.Creator = _userRepository.GetUserById(commentDTO.UserId);
                _commentRepository.CreateComment(comment);
                return comment;

        } catch(Exception ex)
        {
                throw new Exception(ex.Message);
        }
}

        public bool DeleteComment(string commentId)
        {
            try
            {
                _commentRepository.DeleteComment(commentId);
                return true;

            }
            catch
            {
                throw new Exception("Error while deleting the comment");
            }
        }

        public Comment GetComment(string commentId)
        {
            try
            {
                return _commentRepository.GetComment(commentId);

            }
            catch
            {
                throw new Exception("Error while getting the comment");
            }
        }

        public CommentResponseDTO GetParentComment(string commentId)
        {
            try
            {
                Comment? comment = _commentRepository.GetComment(commentId).Parent;
                if (comment == null) throw new Exception("It is a parent comment/ tweet so it don't have any ");
                return _helperService.ConvertCommentToCommentResponse(comment);

            }
            catch
            {
                throw new Exception("Error while getting the parent comment");
            }
        }

        public List<CommentResponseDTO> GetReplies(string commentId)
        {
            //try
            //{
                List<Comment> replies = _commentRepository.GetChildren(commentId);
                List<CommentResponseDTO> responseDTOs = new List<CommentResponseDTO>();
                foreach(Comment comment in replies)
                {
                    if (comment == null) continue;
                    Console.WriteLine(comment.Content);
                    responseDTOs.Add(_helperService.ConvertCommentToCommentResponse(comment));
                }
                return responseDTOs;

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error while getting the replies " + ex.Message);
            //}
        }

        public List<UserResponseDTO> GetUsersLikedTheComment(string commentId)
        {
            try
            {
                List<Like> Likes = _likeRepository.GetAllLikesUnderAComment(commentId);
                List<UserResponseDTO> users = new List<UserResponseDTO>();
                foreach (Like like in Likes)
                {
                    users.Add(_helperService.UserToUserResponse(like.User));
                }
                return users;

            }
            catch
            {
                throw new Exception("Error while getting the likes");
            }
        }

        public bool LikeOps(string commentId, string userId, bool ops)
        {
            try
            {
                Comment comment = _commentRepository.GetComment(commentId);
                User user = _userRepository.GetUserById(userId);
                if (user == null) throw new Exception("User Does not exixits");
                if (ops)
                {
                    Console.WriteLine(_likeRepository.GetLike(userId, commentId));
                    if (_likeRepository.GetLike(userId, commentId) != null) throw new Exception("User already like the comment");
                    Like like = new Like();
                    like.UserId = userId;
                    like.User = user;
                    like.CommentId = commentId;
                    like.Comment = comment;
                    _likeRepository.CreateLike(like);
                    
                } else
                {
                    Like? like = _likeRepository.GetLike(userId, commentId);
                    if (like == null) throw new Exception("User already not liked the comment");
                    
                    _likeRepository.RemoveLike(like);
                }
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while liking " + ex.Message);
            }
        }

        public Comment UpdateComment(CommentDTO commentDTO, string commentId)
        {
            try
            {
                Comment comment = new Comment();
                comment.Attachment = commentDTO.Attachment;
                comment.Content = commentDTO.Content;
                return _commentRepository.UpdateComment(comment, commentId);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating the comment " + ex.Message);
            }
        }
    }
}
