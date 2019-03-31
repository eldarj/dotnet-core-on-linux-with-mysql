using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class CategoryEditVM
    {
        public int CatId { get; set; }
        [Display(Name = "Naziv kategorije", Prompt = "Npr. Sport, Politika ili Filmovi")]
        public string Name { get; set; }
    }
}
