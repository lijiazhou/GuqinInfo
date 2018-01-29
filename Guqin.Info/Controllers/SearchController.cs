using System;
using System.Web.Mvc;
using Guqin.Info.Data.Configuration.ConfigurationModel.CfgActivity;

namespace Guqin.Info.MVC.Controllers
{
    [AllowAnonymous]
    public class SearchController : BaseController
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Search()
        {
            return View();
        }

        protected override void InitilizeActivityConf()
        {
            this.ActivityCfg = ActivityConfig.Create(
                this.ProjectConf.ProjectID,
                Convert.ToInt32(this.AppSetting["SearchActivityID"]),
                this.DataContext.ConfigurationEntities);
        }
    }
}