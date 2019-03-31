using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Filters
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(bool admin) : base(typeof(Attribute))
        {
            Arguments = new object[] { admin };
        }
    }
}
