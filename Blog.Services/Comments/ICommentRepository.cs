using Blog.Models.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comments
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetComments(int postId);

        Task AddComment(Comment comment);

        Task DeleteComment(int id);

        Task UpdateComment(Comment comment);
    }
}
