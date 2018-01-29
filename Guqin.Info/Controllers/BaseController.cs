using Guqin.Info.Data.Context;
using System.Web.Mvc;
using System;
using System.Configuration;
using System.Collections.Specialized;
using Guqin.Info.Data.Configuration.ConfigurationModel.CfgProject;
using Guqin.Info.Data.Configuration.ConfigurationModel.CfgMenuModel;
using Guqin.Info.Data.Configuration.ConfigurationModel.CfgActivity;
using System.Web;

namespace Guqin.Info.MVC.Controllers
{
    public abstract class BaseController : Controller
    {
        private DataContext _dataContext { set; get; }
        private ProjectConfig _projectConf { set; get; }
        private MenuConfig _mainMenuConf { set; get; }
        private NameValueCollection _appSetting { get { return ConfigurationManager.AppSettings; } }
        protected DataContext DataContext { get { return _dataContext; } }
        protected ProjectConfig ProjectConf { get { return _projectConf; } }
        protected NameValueCollection AppSetting { get { return _appSetting; } }
        protected ActivityConfig ActivityCfg { set; get; }
        protected MenuConfig MainMenuConf { get { return _mainMenuConf; } }
        protected HttpContext CurrentContext { get { return System.Web.HttpContext.Current; } }

        protected BaseController() : base()
        {
            this.InitializeDataContext();
            this.InitializeProjectConf();
            this.InitilizeActivityConf();
            this.InitializeMenuConf();
            this.SetPageConf();
        }

        private void InitializeDataContext()
        {
            this._dataContext = new DataContext();
        }

        private void InitializeProjectConf()
        {
            this._projectConf = ProjectConfig.
                Create(
                Convert.ToInt32(AppSetting["ProjectID"]), 
                this.DataContext.ConfigurationEntities);
        }

        private void InitializeMenuConf()
        {
            _mainMenuConf = MenuConfig.
                Create(
                this.ProjectConf.ProjectID, 
                this.DataContext.ConfigurationEntities);
        }

        private void SetPageConf()
        {
            this.ViewBag.projectConfig = this.ProjectConf;
            this.ViewBag.activityConfig = this.ActivityCfg;
            this.ViewBag.menuConfig = this.MainMenuConf;
        }

        protected abstract void InitilizeActivityConf();
    }
}