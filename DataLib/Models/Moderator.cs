using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Models
{
    public class Moderator : User
    {
        public virtual ICollection<Post> Posts { get; set; }
    }
}
