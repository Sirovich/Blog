using Blog.DataLayer;
using Blog.Models;
using Blog.Models.Posts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private PostContext postContext;

        public CommentRepository()
        {
            var settings = new Settings
            {
                ConnectionString = "mongodb+srv://admin:ranger123455@cluster0-xab2r.mongodb.net/test?retryWrites=true&w=majority",
                Database = "PostsDb"
            };

            postContext = new PostContext(settings);
        }

        public async Task AddComment(Comment comment)
        {
            await postContext.Comments.InsertOneAsync(comment);
        }

        public async Task DeleteComment(int id)
        {
            await postContext.Comments.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetComments(int postId)
        {
            var comments = await postContext.Comments.FindAsync(x => x.PostId == postId);
            return comments.ToEnumerable();
        }

        public async Task UpdateComment(Comment comment)
        {
            var filter = Builders<Comment>.Filter.Eq(s => s.Id, comment.Id);
            var update = Builders<Comment>.Update.Set(s => s.CreatedDate, comment.CreatedDate)
                                              .Set(s => s.CreatedUser, comment.CreatedUser)
                                              .Set(s => s.Text, comment.Text)
                                              .Set(s => s.PostId, comment.PostId);

            await postContext.Comments.UpdateOneAsync(filter, update);
        }
    }
}
