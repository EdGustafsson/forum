using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Posts
{
    public class SqlitePostRepository : IPostRepository
    {

        private const string _connectionstring = "Data Source=.\\forum.db";


        public void PrintAllPosts(int threadId)
        {
            int i = 1;
            IList<Post> results = GetAllPosts(threadId);

            foreach (var result in results)
            {

                Console.WriteLine(i + " " + result.Content);
                i++;
            }
        }

        public IList<Post> GetAllPosts(int threadId)
        {
            using var connection = new SqliteConnection(_connectionstring);

            var output = connection.Query<Post>($"SELECT * FROM Post WHERE ThreadId={threadId}");

            return output.ToList();
        }
    }
}
