using System;
using System.Collections.Generic;
using System.Text;
using Forum.Users;

namespace Forum
{
    class Login
    {
        private static IUserRepository _userRepository;

        public Login(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User LoginUser()
        {
            while (true)
            {


                User activeUser;

                Console.WriteLine("\nEnter user ID:");
                string userInput1 = Console.ReadLine();
                Console.WriteLine("\nEnter user password");
                string userInput2 = Console.ReadLine();

                if (_userRepository.UserExists(userInput1, userInput2))
                {

                    activeUser = _userRepository.GetUser(userInput1);

                    Console.WriteLine("\nSuccessful Log in\n");

                    return activeUser;

                }

                Console.WriteLine("Wrong ID or password");

            }


        }
    }
}
