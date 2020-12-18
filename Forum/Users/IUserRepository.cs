using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Users
{
    public interface IUserRepository
    {
        void PrintVersion();
        bool UserExists(string userName, string password);
        User GetUser(string userName);

    }
}
