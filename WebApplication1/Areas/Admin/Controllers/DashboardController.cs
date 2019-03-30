using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Helpers;
using WebApplication1.Areas.Admin.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class DashboardController : AdminController
    {
        private MyContext ctx;
        public DashboardController(MyContext db)
        {
            ctx = db;
        }

        //[Route("dashboard")]
        public IActionResult Index(string layout)
        {
            DashboardVM Model = new DashboardVM
            {
                TotalPosts = ctx.Posts.Count(),
                TotalCategories = ctx.Categories.Count()
            };

            return View(Model);
        }
    }
}