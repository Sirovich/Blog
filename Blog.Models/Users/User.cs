using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Models.Users
{
    public class User
    {
        [BsonId]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}