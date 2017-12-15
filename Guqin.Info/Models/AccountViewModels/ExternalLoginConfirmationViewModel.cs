using System;
using System.ComponentModel.DataAnnotations;

namespace Guqin.Info.MVC.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }
    }
}