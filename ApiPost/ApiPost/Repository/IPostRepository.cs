using ApiPost.Models;

namespace ApiPost.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<IEnumerable<Post>> GetPostsByUserId(int id);
        Task<Post> GetPostsById(int id);
        Task<Post> CreatePost(Post post);
        Task<Post> UpdatePost(Post post);
        Task<bool> DeletePost(int id);
    }
}
