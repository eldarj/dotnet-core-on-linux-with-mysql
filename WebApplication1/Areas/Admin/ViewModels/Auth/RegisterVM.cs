using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Username", Prompt = "Username *")]
        [StringLength(50, ErrorMessage = "Username ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string Username { get; set; }

        [Display(Name = "Password", Prompt = "Password *")]
        [StringLength(50, ErrorMessage = "Password ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string Password { get; set; }

        [Display(Name = "Password", Prompt = "Potvrdi assword *")]
        [StringLength(50, ErrorMessage = "Password ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Email", Prompt = "Email *")]
        [StringLength(50, ErrorMessage = "Email ne smije biti kraći od 4 karaktera!", MinimumLength = 4)]
        public string Email { get; set; }

        [Display(Name = "Ime", Prompt = "Ime")]
        [StringLength(50, ErrorMessage = "Ime ne smije biti kraće od 4 karaktera!", MinimumLength = 4)]
        public string Firstname { get; set; }

        [Display(Name = "Prezime", Prompt = "Prezime")]
        [StringLength(50, ErrorMessage = "Prezime ne smije biti kraće od 4 karaktera!", MinimumLength = 4)]
        public string Lastname { get; set; }

        public string Phone { get; set; }
    }
}
