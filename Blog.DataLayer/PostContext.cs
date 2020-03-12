using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Blog.Models;
using Blog.Models.Posts;

namespace Blog.DataLayer
{
    public class PostContext
    {
        private readonly IMongoDatabase _database = null;

        public PostContext(Settings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Database);
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return _database.GetCollection<Post>("Post");
            }
        }

        public IMongoCollection<Comment> Comments
        {
            get
            {
                return _database.GetCollection<Comment>("Comment");
            }
        }
    }
}
