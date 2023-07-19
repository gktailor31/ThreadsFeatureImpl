using ThreadsFeature.Models;

namespace ThreadsFeature.IRepository
{
    public interface LikeRepository
    {
        public List<Like> GetAllLikesByUser(string userId);
        public List<Like> GetAllLikesUnderAComment(string commentId);
        public Like CreateLike(Like like);
        public Like RemoveLike(Like like);
        public Like? GetLike(string userId, string commentId);
    }
}
