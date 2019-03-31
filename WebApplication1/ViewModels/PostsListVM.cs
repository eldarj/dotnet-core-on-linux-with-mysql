using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class PostsListVM
    {
        public List<ItemInfo> Items { get; set; }
        public class ItemInfo
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}
