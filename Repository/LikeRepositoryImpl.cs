using ThreadsFeature.Data;
using ThreadsFeature.IRepository;
using ThreadsFeature.Models;

namespace ThreadsFeature.Repository
{
    public class LikeRepositoryImpl : LikeRepository
    {
        private ILogger<CommentRepositoryImpl> _logger;
        private readonly ThreadsFeatureDbContext _context;
        public LikeRepositoryImpl(ILogger<CommentRepositoryImpl> logger, ThreadsFeatureDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public List<Like> GetAllLikesByUser(string userId)
        {
            List<Like> likes = _context.likes.Where(e => e.UserId == userId).ToList();
            return likes;
        }

        public List<Like> GetAllLikesUnderAComment(string commentId)
        {
            List <Like> likes = _context.likes.Where(e => e.CommentId == commentId).ToList();
            return likes;
        }

        public Like CreateLike(Like like)
        {
            _context.likes.Add(like);
            _context.SaveChanges();
            return like;
        }

        public Like RemoveLike(Like like)
        {
            _context.likes.Remove(like);
            _context.SaveChanges();
            return like;
        }

        public Like? GetLike(string userId, string commentId)
        {
            return _context.likes.Where(e => e.UserId == userId && e.CommentId == commentId).FirstOrDefault();
        }
    }
}
