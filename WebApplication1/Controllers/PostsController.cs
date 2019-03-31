using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class PostsController : Controller
    {
        private readonly MyContext ctx;
        public PostsController(MyContext db)
        {
            ctx = db;
        }

        [Route("categories/{catname}")]
        public IActionResult Index(string catname)
        {
            PostsListVM x = new PostsListVM
            {
                Items = ctx.Posts.Where(p => p.Category.Name == catname)
                    .Select(p => new PostsListVM.ItemInfo
                    {
                        Title = p.Title,
                        PostId = p.PostID,
                        Body = p.Body
                    })
                    .ToList()
            };
            return View(x);
        }
    }
}