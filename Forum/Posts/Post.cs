using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Posts
{
    public class Post
    {
        public int Id { get; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
