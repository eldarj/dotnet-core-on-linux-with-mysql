using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLib;
using DataLib.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Helpers;
using WebApplication1.Areas.Admin.ViewModels;
using WebApplication1.Helpers;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly MyContext ctx;

        public AuthController(MyContext db)
        {
            ctx = db;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View(new LoginVM
            {
                ZapamtiLogin = true
            });
        }

        public IActionResult Login(LoginVM model)
        {
            HttpContext.Session.Clear();

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            Moderator user = ctx.Moderators
                .SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                ViewData["error_poruka"] = "Pogrešan username ili password!";
                return View("Index", model);
            }

            HttpContext.SetLogiraniModerator(user, model.ZapamtiLogin);
            HttpContext.Session.Set(MyAuthHelper.LOGGED_IN_MOD_NAME, user.Username);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Moderator user = ctx.Moderators
                .SingleOrDefault(x => x.Username == model.Username || x.Email == model.Email);

            if (user != null)
            {
                ViewData["error_poruka"] = "Username ili email je već zauzet!";
                return View(model);
            }

            user = new Moderator
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                DateRegistered = DateTime.Now
            };

            ctx.Add(user);
            ctx.SaveChanges();

            HttpContext.SetLogiraniModerator(user);

            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Logout()
        {
            MyAuthHelper.RemoveCurrentSession(HttpContext);
            return RedirectToAction(nameof(Index), "Home", new { area = "" });
        }
    }
}