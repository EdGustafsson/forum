using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;

namespace Forum.Posts
{
    public interface IPostRepository
    {
        void PrintAllPosts(int threadId);
        IList<PostResult> GetAllPosts(int threadId);
        void AddPost(User activeUser, int threadId);
        void PrintUserPosts(User activeUser, int id);
        void RemovePost(User activeUser, int threadId);
        void UpdatePost(User activeUser, int threadId);
    }
}
