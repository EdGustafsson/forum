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
            IList<PostResult> results = GetAllPosts(threadId);

            foreach (var result in results)
            {

                Console.WriteLine(result.UserName + " " + result.Content);
                i++;
            }
        }

        public IList<PostResult> GetAllPosts(int threadId)
        {
            using var connection = new SqliteConnection(_connectionstring);

          //  var output = connection.Query<Post>($"SELECT * FROM Post WHERE ThreadId={threadId}");

            var output = connection.Query<PostResult>($"SELECT P.Id,P.Content,U.UserName FROM User U INNER JOIN Post P on U.Id = P.UserId WHERE ThreadId={threadId}");

            return output.ToList();
        }

    }
    public class PostResult
    {
        public int Id;
        public string Content;
        public string UserName;
    }
}
