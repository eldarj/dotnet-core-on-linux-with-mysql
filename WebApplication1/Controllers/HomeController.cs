using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext ctx;
        public HomeController(MyContext db)
        {
            ctx = db;
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM
            {
                Latest = ctx.Posts
                    .Select(p => new PostsListVM.ItemInfo
                    {
                        PostId = p.PostID,
                        Title = p.Title,
                        Body = p.Body,
                        Description = p.Description,
                        DateCreatedStr = p.DateCreated.ToString("dd.MM.yyyy"),
                        WrittenBy = p.Moderator.Username,
                        TotalComments = 0,
                        TotalHits = p.Hits
                    })
                    .ToList(),
                AllCategories = new CategoriesListVM
                {
                    Items = ctx.Categories
                        .Select(c => new CategoriesListVM.CategoryInfo
                        {
                            CatId = c.CategoryID,
                            Name = c.Name,
                            PostCount = ctx.Posts.Where(p => p.CategoryId == c.CategoryID).Count()
                        })
                        .ToList()
                }
            };
            return View(model);
        }

        public IActionResult Single(int id)
        {
            var x = ctx.Posts.SingleOrDefault(p => p.PostID == id);
            if (x == null)
            {
                return NotFound();
            }

            x.Hits++;
            ctx.SaveChanges();

            SinglePostVM model = new SinglePostVM
            {
                PostId = x.PostID,
                Title = x.Title,
                Body = x.Body,
                Description = x.Description,
                WrittenBy = ctx.Moderators.Find(x.ModeratorId)?.Username,
                DateCreatedStr = x.DateCreated.ToString("dd.MM.yyyy"),
                TotalComments = 0,
                TotalHits = x.Hits
            };
            return View(model);
        }

        public IActionResult About(string name)
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
