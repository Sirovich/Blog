using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Blog.Models;
using Blog.Models.Users;

namespace Blog.DataLayer
{
    public class UserContext
    {
        private readonly IMongoDatabase _database = null;

        public UserContext(Settings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Database);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }
    }
}
