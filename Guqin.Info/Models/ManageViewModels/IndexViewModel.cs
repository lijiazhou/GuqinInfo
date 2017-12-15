using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace Guqin.Info.MVC.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public Boolean HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public String PhoneNumber { get; set; }
        public Boolean TwoFactor { get; set; }
        public Boolean BrowserRemembered { get; set; }
    }
}