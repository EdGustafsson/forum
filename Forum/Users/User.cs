using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Users
{
    public class User
    {
        public User(string id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
