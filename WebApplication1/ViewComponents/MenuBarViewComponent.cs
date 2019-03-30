using DataLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.ViewComponents
{
    [ViewComponent(Name = "MenuBar")]
    public class MenuBarViewComponent : ViewComponent
    {
        private readonly MyContext ctx;

        public MenuBarViewComponent(MyContext db)
        {
            ctx = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoriesListVM {
                Items = ctx.Categories
                    .Select(c => new CategoriesListVM.CategoryInfo { CatId = c.CategoryID, Name = c.Name})
                    .Take(9)
                    .ToList()
            });
        }
    }
}
