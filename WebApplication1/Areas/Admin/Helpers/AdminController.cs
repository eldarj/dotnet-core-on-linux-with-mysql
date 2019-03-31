using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Areas.Admin.Filters;

namespace WebApplication1.Areas.Admin.Helpers
{
    [Area("Admin")]
    [Auth(moderator: true)]
    public class AdminController : Controller
    {
    }
}