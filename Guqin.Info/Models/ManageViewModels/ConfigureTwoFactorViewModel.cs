using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Guqin.Info.MVC.Models.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public String SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
    }
}