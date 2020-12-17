using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;

namespace Forum.Users
{
    public class SqliteUserRepository : IUserRepository
    { 
        private const string _connectionstring = "Data Source=.\\forum.db";
         
        public void PrintVersion()
        {
            using var connection = new SqliteConnection(_connectionstring);
            
                Console.WriteLine(connection.ServerVersion);
            


        }

        //public User GetUser(string userName)
        //{
        //}
        public User GetUser(int userId)
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<User>($"SELECT * FROM User WHERE Id='{userId}'");

            User activeUser = output.First();

            return activeUser;

        }
        public User GetUser(string userName)
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<User>($"SELECT * FROM User WHERE UserName='{userName}'");

            User activeUser = output.First();

            return activeUser;

        }

        public bool UserExists(string userName, string password)
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<User>($"SELECT * FROM User WHERE UserName='{userName}' AND Password='{password}'");

            if (output.Any())
            {
                return true;
            }
            else
            {
                return false;
            }



        }

    }
}
