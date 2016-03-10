using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using dannyallegrezzaBlog.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dannyallegrezzaBlog.Controllers
{
    public class PostsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Post/Create
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                return View(post);
            }

            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            return View();
        }

        // GET: /Post/Create
        [HttpGet]
        public IActionResult Create()
        {        
            return View();
        }

        public IActionResult Post(long id)
        {
            var post = new Post();
            post.SetDescription("This is a description!");
            post.Title = "Hello World - MY title";
            post.Author = "Dan Allegrezza";
            post.PostedDate = DateTime.Now;
            post.Body = "As the body of this blog post, I command you give me attention!";

            // Sample: Use the ViewBag to pass in Data to the View
            ViewBag.Title = "A brand new Post!";
            ViewBag.Author = "Danny Allegrezza";
            ViewBag.PostedOn = DateTime.Now;
            ViewBag.Body = "This is my first blog post. I hope you enjoy ;) ";

            return View(post);
        }


    }
}
