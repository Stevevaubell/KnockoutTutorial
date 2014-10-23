using MvcApplication.Models.Json;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MvcApplication.Controllers
{
    public class BlogPostController : ApiController
    {
        [HttpGet]
        public IList<Post> Get()
        {
            PersonNameGenerator generator = new PersonNameGenerator();
            Random random = new Random();
            return Enumerable.Range(0, random.Next(0, 9))
                             .Select(x => new Post
                                 {
                                     Id = x,
                                     Author = generator.GenerateRandomFirstAndLastName(),
                                     Body = Ipsum.GetPhrase(100),
                                     PostedDate = DateTime.Now,
                                     Title = Ipsum.GetPhrase(5)
                                 })
                             .ToList();
        }

        [HttpPost]
        public bool Post(Post post)
        {
            //Simple validation
            if (post != null && 
                !string.IsNullOrEmpty(post.Author) &&
                !string.IsNullOrEmpty(post.Title) &&
                !string.IsNullOrEmpty(post.Body))
            {
                return true; // do save here if there was a data access layer
            }
            return false;
        }
    }
}
