using System;

namespace MvcApplication.Models.Json
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTime PostedDate { get; set; } 
    }
}