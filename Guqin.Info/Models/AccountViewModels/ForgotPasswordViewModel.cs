using System;
using System.ComponentModel.DataAnnotations;


namespace Guqin.Info.MVC.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }
    }
}