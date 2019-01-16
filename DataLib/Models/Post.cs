using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public virtual Category Category { get; set; }
    }
}
