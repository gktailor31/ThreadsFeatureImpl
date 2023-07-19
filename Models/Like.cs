namespace ThreadsFeature.Models
{
    public class Like
    {
        public string UserId { get; set; }
        virtual public User User { get; set; }
        public string CommentId { get; set; }
        virtual public Comment Comment { get; set; }
    }
}
