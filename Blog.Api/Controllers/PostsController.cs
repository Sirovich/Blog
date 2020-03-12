using System.Threading.Tasks;
using Blog.Models.Posts;
using Blog.Services.Comments;
using Blog.Services.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;

        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postRepository.GetPosts();
            return Ok(posts);
        }

        [HttpPut]
        public async Task UpdatePost([FromBody]PostRequest post)
        {
            await postRepository.UpdatePost(post);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await postRepository.GetPost(id);
            return Ok(post);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody]PostRequest post)
        {
            await postRepository.AddPost(post);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await postRepository.DeletePost(id);
            return Ok();
        }
    }
}
