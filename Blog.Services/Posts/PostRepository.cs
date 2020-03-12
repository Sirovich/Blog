using Blog.DataLayer;
using Blog.Models;
using Blog.Models.Posts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace Blog.Services.Posts
{
    public class PostRepository : IPostRepository
    {
        private PostContext postContext;
        private IMapper mapper;

        public PostRepository(IMapper mapper, IConfiguration configuration)
        {
            var settings = new Settings
            {
                ConnectionString = configuration.GetConnectionString("MongoDb"),
                Database = "PostsDb"
            };

            postContext = new PostContext(settings);
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddPost(PostRequest request)
        {
            var post = mapper.Map<PostRequest, Post>(request);
            await postContext.Posts.InsertOneAsync(post);
        }

        public async Task DeletePost(int id)
        {
            await postContext.Posts.DeleteOneAsync(Builders<Post>.Filter.Eq("Id", id));
        }

        public async Task<Post> GetPost(int id)
        {
            return await postContext.Posts.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await postContext.Posts.Find(_ => true).ToListAsync();
        }

        public async Task UpdatePost(PostRequest request)
        {
            var post = mapper.Map<Post>(request);
            var filter = Builders<Post>.Filter.Eq(s => s.Id, post.Id);
            var update = Builders<Post>.Update.Set(s => s.Category, post.Category)
                                              .Set(s => s.CreatedDate, post.CreatedDate)
                                              .Set(s => s.CreatedUser, post.CreatedUser)
                                              .Set(s => s.Text, post.Text)
                                              .Set(s => s.Title, post.Title);

            await postContext.Posts.UpdateOneAsync(filter, update);
        }
    }
}
