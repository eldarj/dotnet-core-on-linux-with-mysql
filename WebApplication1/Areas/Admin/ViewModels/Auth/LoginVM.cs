using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Username", Prompt = "Username *")]
        [Required]
        [StringLength(50, ErrorMessage = "Username ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string Username { get; set; }

        [Display(Name = "Password", Prompt = "Password *")]
        [Required]
        [StringLength(50, ErrorMessage = "Password ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string Password { get; set; }

        public bool ZapamtiLogin { get; set; }
    }
}
