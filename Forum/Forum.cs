using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;
using Forum.Threads;
using System.Linq;
using Forum.Posts;

namespace Forum
{
    class Forum
    {
        private static IUserRepository _userRepository;
        private static IThreadRepository _threadRepository;
        private static IPostRepository _postRepository;
        private static User _activeUser;
        public Forum(IUserRepository userRepository, User activeUser)
        {
            _userRepository = userRepository;
            _activeUser = activeUser;
        }

        public void ForumMain()
        {

            _threadRepository = new SqliteThreadRepository();
            _postRepository = new SqlitePostRepository();

            while (true)
            {

                IList<ThreadResult> results = _threadRepository.GetAllThreads();


                int i = 1;

                foreach (var result in results)
                {

                    Console.WriteLine(i + " " + result.Title + " " + result.UserName);
                    i++;
                }

                Console.WriteLine("Select Thread with a number or 'C' to create new thread");

            string selection = Console.ReadLine();

                if (selection == "c")
                {
                    _threadRepository.AddThread(_activeUser);
                }
                else if (_threadRepository.ThreadExists(selection))
                {

                    int selectionNumber = Convert.ToInt32(selection) - 1;

                    Console.WriteLine(results[selectionNumber].Title);
                    Console.WriteLine(results[selectionNumber].UserName);

                    _postRepository.PrintAllPosts(results[selectionNumber].Id);

                }



            }
        }


    }
}
