using System;
using System.Collections.Generic;

namespace Guqin.Info.MVC.Models.AccountViewModels
{
    public class SendCodeViewModel
    {
        public String SelectedProvider { get; set; }

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public String ReturnUrl { get; set; }

        public Boolean RememberMe { get; set; }
    }
}