using ThreadsFeature.Data;
using ThreadsFeature.IRepository;
using ThreadsFeature.Models;

namespace ThreadsFeature.Repository
{
    public class CommentRepositoryImpl : CommentRepository
    {
        private ILogger<CommentRepositoryImpl> _logger;
        private readonly ThreadsFeatureDbContext _context;
        public CommentRepositoryImpl(ILogger<CommentRepositoryImpl> logger, ThreadsFeatureDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Comment CreateComment(Comment comment)
        {
            try
            {
                _context.comments.Add(comment);
                _context.SaveChanges();
                return comment;
            } catch
            {
                throw new Exception("Creation of comment Unsusccessful");
            }
        }

        public Comment DeleteComment(string id)
        {
            try
            {
                Comment? comment = _context.comments.Find(id);
                if (comment == null) throw new Exception($"Comment doesn't exixits with {id}");
                _context.comments.Remove(comment);
                _context.SaveChanges();
                return comment;
            }
            catch
            {
                throw new Exception("Deletion of comment Unsusccessful");
            }
        }

        public Comment GetComment(string id)
        {
            try{
                Comment? comment = _context.comments.Find(id);
                if (comment == null) throw new Exception($"No Comment Find with {id}");
                return comment;
            } catch
            {
                throw new Exception("Getting of comment Unsusccessful");
            }
        }

        public Comment UpdateComment(Comment comment, string id)
        {
            try
            {
                Comment? exisitingComment = _context.comments.Find(id);
                if (exisitingComment == null) throw new Exception($"No Comment Find with {id}");
                exisitingComment.Attachment = comment.Attachment;
                exisitingComment.Content = comment.Content;
                _context.comments.Update(exisitingComment);
                _context.SaveChanges();
                return _context.comments.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Updation of comment Unsusccessful " + ex.Message);
            }
        }

        public List<Comment> GetChildren(string commentId)
        {
            try
            {
                return _context.comments.Where(e => e.ParentId == commentId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
