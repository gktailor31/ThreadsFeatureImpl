using ThreadsFeature.Models;

namespace ThreadsFeature.IRepository
{
    public interface CommentRepository
    {
        public Comment CreateComment(Comment comment);
        public Comment UpdateComment(Comment comment, string id);
        public Comment DeleteComment(string id);
        public Comment GetComment(string id);
        public List<Comment> GetChildren(string commentId);
        //public List<User> GetUsersLikedTheComment(int commentId);
        //public List<Comment> GetAllReplies(int commentId);
        //public Comment GetParentComment(int commentId);

    }
}
