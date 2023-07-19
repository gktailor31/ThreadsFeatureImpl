namespace ThreadsFeature.DTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public string? Attachment { get; set; }
        public string UserId { get; set; }
        public string? ParentCommentId { get; set; }
    }
}
