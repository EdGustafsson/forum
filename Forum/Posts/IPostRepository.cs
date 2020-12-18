using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Posts
{
    public interface IPostRepository
    {
        void PrintAllPosts(int threadId);
        IList<Post> GetAllPosts(int ThreadId);
    }
}
