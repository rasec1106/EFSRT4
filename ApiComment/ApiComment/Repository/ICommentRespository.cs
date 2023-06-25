
using System;
using ApiComment.Dtos;
namespace ApiComment.Repository
{
    public interface ICommentRespository
    {

        Task<IEnumerable<CommentDto>> GetComments();
        Task<IEnumerable<CommentDto>> GetCommentsByPostId(int postId);
        Task<IEnumerable<CommentDto>> GetCommentsByUserId(int userId);
        Task<CommentDto> GetCommentById(int commentId);
        Task<CommentDto> CreateComment(CommentDto commentDto);
        Task<CommentDto> UpdateComment(CommentDto commentDto);
        Task<bool> DeleteComment(int commentId);

    }
}
