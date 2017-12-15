using System;
using System.ComponentModel.DataAnnotations;

namespace Guqin.Info.MVC.Models.ManageViewModels
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public String Number { get; set; }
    }
}