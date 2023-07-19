using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ThreadsFeature.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        //[JsonIgnore]
        virtual public List<Comment> Comments { get; set; } = new List<Comment>();
        //[JsonIgnore]
        virtual public List<Like> LikedComments { get; set; } = new List<Like>();
    }
}
