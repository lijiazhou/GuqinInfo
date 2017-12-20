using System.Web.Mvc;
using System.Web.Routing;
using Common.Static.Settings.Const;
using Common.Static.Utility.Model;
using Common.Static.Utility.Decoding;
using System;

namespace Guqin.Info.MVC.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            this.ExecuteAuthValidation(filterContext);
            base.OnActionExecuted(filterContext);
        }

        private void ExecuteAuthValidation(ActionExecutedContext filterContext)
        {
            String token = filterContext.HttpContext.Session[KeyConst.USER_TOKEN_KEY].ToString();
            AuthModel authModel = Decoder.DecodeAccessToken(token);
            if (!authModel.IsValid)
            {
                filterContext.Result = this.RedirectToLogin(filterContext.HttpContext.Request.Url.ToString());
            }
           
            //data base access to validate auth
            
        }

        private RedirectToRouteResult RedirectToLogin(String url)
        {
            return new RedirectToRouteResult(
                    "Account/Login",                  
                    new RouteValueDictionary {
                        {
                            "from",
                            url
                        } });
        }
    }
}