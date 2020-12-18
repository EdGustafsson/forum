using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.Users;

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

        public void AddPost(User activeUser, int threadId)
        {
            using var connection = new SqliteConnection(_connectionstring);

            Console.WriteLine("Write a post or input 'x' to exit");
            string userInput = Console.ReadLine();

            if (userInput == "x")
            {
                return;
            }
            else
            {
                Post newPost = new Post();

                newPost.ThreadId = threadId;
                newPost.UserId = activeUser.Id;
                newPost.Content = userInput;

                var sql = $"INSERT INTO Post (ThreadId, UserId, Content) VALUES(@ThreadId, @UserId, @Content)";

                connection.Execute(sql, newPost);
            }
        }
    }
    public class PostResult
    {
        public int Id;
        public string Content;
        public string UserName;
    }
}
