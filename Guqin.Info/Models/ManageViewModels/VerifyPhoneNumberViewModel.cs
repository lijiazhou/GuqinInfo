using System;
using System.ComponentModel.DataAnnotations;

namespace Guqin.Info.MVC.Models.ManageViewModels
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public String Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }
    }
}