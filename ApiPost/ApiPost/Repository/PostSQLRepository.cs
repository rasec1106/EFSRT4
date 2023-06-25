using ApiPost.DbContexts;
using ApiPost.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPost.Repository
{
    public class PostSQLRepository : IPostRepository
    {
        private AppDbContext dbContext;
        
        public PostSQLRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post> GetPostsById(int id)
        {
            Post post = await dbContext.Posts.FirstOrDefaultAsync(item => item.PostId == id);
            return post;
        }

        public async Task<Post> CreatePost(Post post)
        {
            dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            dbContext.Posts.Update(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            Post post = await dbContext.Posts.FirstOrDefaultAsync(item => item.PostId == id);
            if (post == null)
            {
                return false;
            }
            dbContext.Posts.Remove(post);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(int id)
        {
            return await dbContext.Posts.Where(p=>p.UserId == id).ToListAsync();
        }
    }
}
