using Blog.Models.Posts;
using Blog.Services.Comments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentRepository commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetComments(int postId)
        {
            var comments = await commentRepository.GetComments(postId);
            return Ok(comments);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await commentRepository.DeleteComment(id);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(comment);
            }

            await commentRepository.UpdateComment(comment);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(comment);
            }

            await commentRepository.AddComment(comment);
            return Ok();
        }
    }
}
