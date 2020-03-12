using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Posts
{
    public class Comment
    {
        [BsonId]
        private ObjectId DbId { get; set; }

        public int Id { get; set; }

        public string Text { get; set; }

        public string CreatedUser { get; set; }

        public int PostId { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedDate { get; set; }

        public Comment()
        {
            DbId = ObjectId.GenerateNewId();
            Id = DbId.GetHashCode();
        }
    }
}
