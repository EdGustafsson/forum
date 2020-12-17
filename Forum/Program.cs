﻿using System;
using Forum.Users;

namespace Forum
{
    class Program
    {        
        private static IUserRepository _userRepository;
        private static Login _login;
        private static User _activeUser;
        static void Main(string[] args)
        {
            Console.WriteLine("Forum");

            _userRepository = new SqliteUserRepository();



            _login = new Login(_userRepository);
            _activeUser = _login.LoginUser();
        }
    }
}
