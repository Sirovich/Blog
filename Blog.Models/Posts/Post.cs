using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Blog.Models.Posts
{
    public class Post
    {
        [BsonId]
        private ObjectId DbId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string CreatedUser { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedDate { get; set; }

        public string Category { get; set; }

        public Post()
        {
            DbId = ObjectId.GenerateNewId();
            Id = DbId.GetHashCode();
        }
    }
}
