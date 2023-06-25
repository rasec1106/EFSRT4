using System.ComponentModel.DataAnnotations;

namespace ApiComment.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public string? Content { get; set; }
        // public string? ImageUrl { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? PostId { get; set; }

    }
}

