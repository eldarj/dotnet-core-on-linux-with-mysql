using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CategoriesListVM
    {
        public List<CategoryInfo> Items { get; set; }
        public class CategoryInfo
        {
            public int CatId { get; set; }
            public string Name { get; set; }
        }
    }
}
