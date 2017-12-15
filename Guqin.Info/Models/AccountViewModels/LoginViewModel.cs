using System;
using System.ComponentModel.DataAnnotations;

namespace Guqin.Info.MVC.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Display(Name = "Remember me?")]
        public Boolean RememberMe { get; set; }
    }
}