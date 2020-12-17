using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Threads
{
    public class Thread
    {
        public string Id { get; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
