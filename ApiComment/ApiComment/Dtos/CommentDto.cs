using System.ComponentModel.DataAnnotations;

namespace ApiComment.Dtos
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int? UserId { get; set; }
        public string? Content { get; set; }
        // public string? ImageUrl { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? PostId { get; set; }

    }
}
