using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPost.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImageUrl { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? PublicationDate { get; set; }
    }
}
