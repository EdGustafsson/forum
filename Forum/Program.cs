using System;
using Forum.Users;

namespace Forum
{
    class Program
    {        
        private static IUserRepository _userRepository;
        private static Login _login;
        static void Main(string[] args)
        {
            Console.WriteLine("Forum");

            _userRepository = new SqliteUserRepository();

            _login = new Login(_userRepository);
            _login.LoginUser();
        }
    }
}
