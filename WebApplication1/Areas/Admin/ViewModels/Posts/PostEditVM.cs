using DataLib.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class PostEditVM
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public bool PredefinedCategory { get; set; }
    }
}
