using dannyallegrezzaBlog.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dannyallegrezzaBlog.ViewComponents
{
    // This ViewComponent class is used to 
    [ViewComponent(Name = "ArchivedPosts")]
    public class ArchivedPostsViewComponent : ViewComponent
    {
        private readonly BlogDataContext _db;

        public ArchivedPostsViewComponent(dannyallegrezzaBlog.Models.BlogDataContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            var archivedPosts = _db.GetArchivedPosts().ToArray();
            return View(archivedPosts);
        }
    }
}
