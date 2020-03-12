using Blog.Models.Posts;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Posts
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);

        Task AddPost(PostRequest post);

        Task DeletePost(int id);

        Task UpdatePost(PostRequest post);
    }
}
