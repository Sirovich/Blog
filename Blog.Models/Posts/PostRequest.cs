using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Models.Posts
{
    public class PostRequest
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Category { get; set; }
    }
}
