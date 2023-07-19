namespace ThreadsFeature.DTO
{
    public class CommentResponseDTO
    {
        public string Id { get; set; }
        public string Content { get; set; } = "";
        public string? Attachment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Likes { get; set; }
        public int Replies { get; set; }

        public string CreatorName { get; set; }
        
    }
}
