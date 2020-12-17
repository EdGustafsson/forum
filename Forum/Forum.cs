using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;
using Forum.Threads;

namespace Forum
{
    class Forum
    {
        private static IUserRepository _userRepository;
        private static IThreadRepository _threadRepository;
        public Forum(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ForumMain()
        {

            _threadRepository = new SqliteThreadRepository();

            _threadRepository.PrintAllThreads();

            Console.WriteLine("Select Thread with a number or 'C' to create new thread");


        }

    }
}
