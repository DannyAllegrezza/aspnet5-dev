using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using dannyallegrezzaBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dannyallegrezzaBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public IActionResult Index()
        {
            Array posts = new[]
            {
                new Post
                {
                    Title = "Blog Post 1",
                    PostedDate = DateTime.Now,
                    Author = "Danny A",
                    Body = "Blog Post numero uno!"
                },
                new Post
                {
                    Title = "Blog Post 2",
                    PostedDate = DateTime.Now,
                    Author = "Dannyyyy Ayeee",
                    Body = "Blog Post numero dos!"
                }
            };

            return View(posts);
        }

        
        public String Echo(string id)
        {
            return "hello, mr. " + id.ToString();
        }
    }
}
