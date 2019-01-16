using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
