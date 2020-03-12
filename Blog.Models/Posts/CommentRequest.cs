using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Posts
{
    public class CommentRequest
    {
        public string Text { get; set; }

        public string CreatedUser { get; set; }

        public int PostId { get; set; }
    }
}
