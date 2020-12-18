using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using Forum.Users;

namespace Forum.Threads
{
    public class SqliteThreadRepository : IThreadRepository
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

            var output = connection.Query<Result>("SELECT T.Id,T.Title,U.UserName FROM User U INNER JOIN Thread T on U.Id = T.UserId");

            return output.ToList();
        }


        public bool ThreadExists(string threadId)
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<Thread>($"SELECT * FROM Thread WHERE Id={threadId}");

            if (output.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintThread(Thread selectedThread)
        {


        }
    }

    public class Result
    {
        public int Id;
        public string Title;
        public string UserName;
    }

}
