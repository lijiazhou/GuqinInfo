using System;
using System.ComponentModel.DataAnnotations;

namespace Guqin.Info.MVC.Models.AccountViewModels
{
    public class VerifyCodeViewModel
    {
        [Required]
        public String Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        public String ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public Boolean RememberBrowser { get; set; }

        public Boolean RememberMe { get; set; }
    }
}