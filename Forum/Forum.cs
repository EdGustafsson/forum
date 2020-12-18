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
        private static User _activeUser;
        public Forum(IUserRepository userRepository, User activeUser)
        {
            _userRepository = userRepository;
            _activeUser = activeUser;
        }

        public void ForumMain()
        {

            _threadRepository = new SqliteThreadRepository();

            _threadRepository.PrintAllThreads();

            Console.WriteLine("Select Thread with a number or 'C' to create new thread");

            string selection = Console.ReadLine();

            if(selection == "c")
            {
                _threadRepository.AddThread(_activeUser);
            }
        }

    }
}
