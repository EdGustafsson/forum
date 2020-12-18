using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using Forum.Users;

namespace Forum.Threads
{
    class SqliteThreadRepository : IThreadRepository
    {

        private const string _connectionstring = "Data Source=.\\forum.db";
        public void PrintAllThreads()
        {

            int i = 1;
            IList<Result> results = GetAllThreads();

            foreach (var result in results)
            {

                Console.WriteLine(i + " " + result.Title + " " + result.UserName);
                i++;
            }
        }

        public void AddThread(User activeUser)
        {
            using var connection = new SqliteConnection(_connectionstring);

            Console.WriteLine("Write a title:");
            string userInput = Console.ReadLine();

            Thread newThread = new Thread();

            newThread.UserId = activeUser.Id;
            newThread.Title = userInput;

            var sql = $"INSERT INTO Thread (UserId, Title) VALUES(@UserId, @Title)";

            connection.Execute(sql, newThread);
        }

        public IList<Result> GetAllThreads()
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<Result>("SELECT T.Title,U.UserName FROM User U INNER JOIN Thread T on U.Id = T.UserId");

            return output.ToList();
        }

    }

    public class Result
    {
        public string Title;
        public string UserName;
    }

}
