using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;

namespace Forum.Threads
{
    public interface IThreadRepository
    {

        void PrintAllThreads();

        IList<ThreadResult> GetAllThreads();

        void AddThread(User activeUser);

        bool ThreadExists(string threadId);
    }
}
