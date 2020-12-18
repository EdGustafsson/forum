using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;
using Forum.Threads;
using System.Linq;
using Forum.Posts;
using System.Windows;

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

                    //   Console.WriteLine("Write a post or input x to exit");

                    //  string userInput = Console.ReadLine();

                    Console.WriteLine("input 'c' to create a new post");
                    Console.WriteLine("input 'e' to edit your posts");
                    Console.WriteLine("input 'x' to exit");
                    string userInput = Console.ReadLine();

                    if(userInput == "c")
                    {
                        _postRepository.AddPost(_activeUser, results[selectionNumber].Id);
                    }
                    else if(userInput == "e")
                    {
                        // print all posts by _activeuser
                       // then delete or edit
                                   
                        _postRepository.PrintUserPosts(_activeUser, results[selectionNumber].Id);

                        Console.WriteLine("input 'e' to edit a post");
                        Console.WriteLine("input 'd' to delete a post");
                        Console.WriteLine("input 'x' to exit");

                        string userInput2 = Console.ReadLine();

                        if (userInput2 == "d")
                        {
                            _postRepository.RemovePost(_activeUser, results[selectionNumber].Id);
                        }
                        else if (userInput == "e")
                        {
                            _postRepository.UpdatePost(_activeUser, results[selectionNumber].Id);
                        }



                    }
                    

                }



            }
        }


    }
}
