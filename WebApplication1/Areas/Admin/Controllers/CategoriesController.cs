using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using DataLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Areas.Admin.Helpers;
using WebApplication1.Areas.Admin.ViewModels;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CategoriesController : AdminController
    {
        private readonly MyContext ctx;
        public CategoriesController(MyContext db)
        {
            ctx = db;
        }

        public IActionResult Index()
        {
            return View(PrepareCategories());
        }

        public IActionResult IndexPartial()
        {
            return PartialView("Index", PrepareCategories());
        }

        public IActionResult Create(int? catId)
        {
            return PartialView("Edit", new CategoryEditVM
            {
                CatId = catId != null ? (int)catId : 0
            });
        }

        public IActionResult Edit(int id)
        {
            Category x = ctx.Categories.Find(id);
            return PartialView(new CategoryEditVM
            {
                CatId = x.CategoryID,
                Name = x.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CategoryEditVM x)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Edit", x);
            }

            Category category;
            if (x.CatId == 0)
            {
                category = new Category();
                ctx.Add(category);
            }
            else
            {
                category = ctx.Categories.Find(x.CatId);
            }

            category.Name = x.Name;

            ctx.SaveChanges();

            return PartialView("IndexPartial");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await ctx.Categories
                .FirstOrDefaultAsync(c => c.CategoryID == id);
            if (category == null)
            {
                return NotFound();
            }
            ctx.Categories.Remove(category);
            await ctx.SaveChangesAsync();

            return RedirectToAction("IndexPartial");
        }

        #region HelperMethods
        private CategoryListVM PrepareCategories()
        {
            return new CategoryListVM
            {
                Items = ctx.Categories
                    .Select(x => new CategoryListVM.ItemInfo
                    {
                        CatId = x.CategoryID,
                        Name = x.Name,
                        TotalHits = 1249, //TODO
                        TotalLikes = 205, //TODO
                        TotalPosts = ctx.Posts.Where(p => p.Category.CategoryID == x.CategoryID).Count(),
                        PopularPosts = ctx.Posts
                            .Where(p => p.Category.CategoryID == x.CategoryID)
                            .Take(5) //TODO: Order by popularity
                            .ToDictionary(p => p.PostID, p => p.Title)
                    })
                    .ToList()
            };
        }
        #endregion
    }
}