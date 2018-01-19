using System;
using System.Web.Mvc;
using Guqin.Info.Data.Configuration.ConfigurationModel.CfgActivity;
using Guqin.Info.MVC.Attributes;

namespace Guqin.Info.MVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CookieAuthAttribute]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        protected override void InitilizeActivityConf()
        {
            this.ActivityCfg = ActivityConfig.Create(
                this.ProjectConf.ProjectID, 
                Convert.ToInt32(AppSetting["HomeActivityID"]), 
                this.DataContext.ConfigurationEntities);
        }
    }
}