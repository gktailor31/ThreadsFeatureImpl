using ThreadsFeature.DTO;
using ThreadsFeature.Models;

namespace ThreadsFeature.IServices
{
    public interface ThreadService
    {
        public Comment CreateComment(CommentDTO comment);
        public Comment UpdateComment(CommentDTO comment, string commentId);
        public bool DeleteComment(string commentId);
        public Comment GetComment(string commentId);
        public List<UserResponseDTO> GetUsersLikedTheComment(string commentId);
        public List<CommentResponseDTO> GetReplies(string commentId);
        public CommentResponseDTO GetParentComment(string commentId);
        public bool LikeOps(string commentId, string userId, bool ops);
    }
}
