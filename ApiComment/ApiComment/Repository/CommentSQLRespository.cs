

using System;

using AutoMapper;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ApiComment.DbContexts;
using ApiComment.Dtos;
using ApiComment.Models;
using AutoMapper;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.Design;

namespace ApiComment.Repository
{
    public class CommentSQLRespository : ICommentRespository
    {
        private AppDbContext dbContext;
        private IMapper mapper;


        public CommentSQLRespository(AppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CommentDto>> GetComments()
        {
            List<Comment> comments = await this.dbContext.Comments.ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }


        public async Task<CommentDto> GetCommentById(int commentId)
        {
            Comment comment = await dbContext.Comments.Where(comment => comment.CommentId == commentId)
                  .FirstOrDefaultAsync();

            return mapper.Map<CommentDto>(comment);
        }


        public async Task<CommentDto> CreateComment(CommentDto commentDto)
        {
            Comment comment = mapper.Map<Comment>(commentDto);
            this.dbContext.Comments.Add(comment);
            await this.dbContext.SaveChangesAsync();
            return mapper.Map<CommentDto>(comment);

        }

        public async Task<CommentDto> UpdateComment(CommentDto commentDto)
        {
            var comment = mapper.Map<Comment>(commentDto);
            this.dbContext.Update(comment);
            await this.dbContext.SaveChangesAsync();
            return mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            try
            {
                Comment comment = await this.dbContext.Comments
               .FirstOrDefaultAsync(product => product.CommentId == commentId);
                if (comment == null)
                {
                    return false;
                }
                dbContext.Comments.Remove(comment);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByPostId(int postId)
        {
            List<Comment> comments = await this.dbContext.Comments.Where(comment => comment.PostId == postId).ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByUserId(int userId)
        {
            List<Comment> comments = await this.dbContext.Comments.Where(comment => comment.UserId == userId).ToListAsync();
            return mapper.Map<List<CommentDto>>(comments);
        }
    }
}
