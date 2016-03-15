﻿using System;
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
        //Properties
        readonly BlogDataContext _dataContext;

        // Overloaded Constructor: forces a BlogDataContext, which is a dependency, to be injected into the constructor
        public PostsController(BlogDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //********************* CLASS METHODS *************************//
        // GET: /Posts/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Post/Create
        [HttpGet]
        public IActionResult Create()
        {        
            return View();
        }

        // GET: /Posts/Post/<id>
        [HttpGet]
        public IActionResult Post(long id)
        {
            var post = _dataContext.Posts.SingleOrDefault(x => x.Id == id);
            return View(post);
        }

        // POST: /Posts/Create
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            post.PostedDate = DateTime.Now;
            post.Author = User.Identity.Name;

            _dataContext.Posts.Add(post); // step 1: First, tell DataContext everything you want to do
            await _dataContext.SaveChangesAsync(); // step 2: Tell the DataContext to execute whatever we asked for

            return RedirectToAction("Post", new { id = post.Id });
        }
    }
}
