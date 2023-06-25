using ApiPost.Models;
using ApiPost.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiPost.Controllers
{
    [Route("/api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostRepository postRepository;
        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpGet]
        [Route("/GetPosts")]
        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await postRepository.GetPosts();
        }

        [HttpGet]
        [Route("/GetPostsByUserId")]
        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            return await postRepository.GetPostsByUserId(id);
        }

        [HttpGet]
        [Route("/GetPostsById/{id}")]
        public async Task<Post> GetPostsById(int id)
        {
            return await postRepository.GetPostsById(id);
        }

        [HttpPost]
        [Route("/CreatePost")]
        public async Task<Post> CreatePost(Post post)
        {
            return await postRepository.CreatePost(post);
        }

        [HttpPut]
        [Route("/UpdatePost")]
        public async Task<Post> UpdatePost(Post post)
        {
            return await postRepository.UpdatePost(post);
        }

        [HttpDelete]
        [Route("/DeletePost")]
        public async Task<bool> DeletePost(int id)
        {
            return await postRepository.DeletePost(id);
        }
    }
}
