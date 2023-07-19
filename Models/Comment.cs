using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThreadsFeature.Models
{
    public class Comment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CommentId { get; set; }

        [Required]
        public string Content { get; set; }
        public string? Attachment { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreaterId { get; set; }

        
        //[JsonIgnore]
        virtual public User Creator { get; set; }
        //[JsonIgnore]
        virtual public List<Like> Likes { get; set; } = new List<Like>();
        public string? ParentId { get; set; }
        //[JsonIgnore]
        virtual public Comment? Parent { get; set; }
        //[JsonIgnore]
        virtual public List<Comment> Child { get; set; } = new List<Comment>();
    }
}
