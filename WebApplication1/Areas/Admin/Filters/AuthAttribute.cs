using DataLib;
using DataLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Helpers;

namespace WebApplication1.Areas.Admin.Filters
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(bool moderator) : base(typeof(Auth))
        {
            Arguments = new object[] { moderator };
        }
    }

    public class Auth : IAsyncActionFilter
    {
        private readonly bool _moderator;

        public Auth(bool mod)
        {
            _moderator = mod;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Moderator moderator = MyAuthHelper.GetLogiranogModeratora(context.HttpContext);

            if (moderator == null)
            {
                ErrorAndRedirect(context);
                return;
            }

            MyContext db = context.HttpContext.RequestServices.GetService<MyContext>();

            if (_moderator && db.Moderators.Any(m => m.UserID == moderator.UserID))
            {
                await next();
                return;
            }

            ErrorAndRedirect(context);
        }

        private void ErrorAndRedirect(ActionExecutingContext context)
        {
            if (context.Controller is Controller controller)
            {
                controller.TempData["Error"] = "Nemate pravo pristupa!";
            }

            context.Result = new RedirectToActionResult("Index", "Auth", new { area = "Admin" });
        }
    }
}
