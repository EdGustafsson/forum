using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Threads
{
    public interface IThreadRepository
    {

        void PrintAllThreads();

        IList<Result> GetAllThreads();
    }
}
