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
        private readonly BlogDataContext _db;

        public HomeController(BlogDataContext db)
        {
            _db = db;
        }
        // GET: /Home/
        public IActionResult Index(int page = 0)
        {
            int pageSize = 3;                   // Number of Pages
            int skip = page * pageSize;         // Skip Count

            var posts = _db.Posts
                            .OrderByDescending(x => x.PostedDate)
                            .Skip(skip)
                            .Take(pageSize)
                            .ToArray();

            var totalPosts = _db.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            // Check to see if incoming request is an AJAX request - if so, call the partial View Method
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView(posts);
            }

            return View(posts);
        }

        
        public String Echo(string id)
        {
            return "hello, mr. " + id.ToString();
        }

        public IActionResult CauseAnError()
        {
            throw new Exception("Error! Big time error!");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
