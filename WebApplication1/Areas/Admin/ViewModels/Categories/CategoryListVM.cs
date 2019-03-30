using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class CategoryListVM
    {
        public List<ItemInfo> Items;
        public class ItemInfo
        {
            public int CatId { get; set; }
            public string Name { get; set; }
            public int TotalLikes { get; set; }
            public int TotalHits { get; set; }
            public int TotalPosts { get; set; }
            public Dictionary<int, string> PopularPosts { get; set; }
        }
    }
}
