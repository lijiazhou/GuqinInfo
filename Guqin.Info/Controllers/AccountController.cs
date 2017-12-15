using Guqin.Info.Data.Configuration.ConfigurationModel.CfgActivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guqin.Info.MVC.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        protected override void InitilizeActivityConf()
        {
            this.ActivityCfg = ActivityConfig.Create(
                this.ProjectConf.ProjectID,
                Convert.ToInt32(this.AppSetting["AccountActivityID"]),
                this.DataContext.ConfigurationEntities);
        }
    }
}