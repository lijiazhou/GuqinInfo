using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Common.Static.Settings.Const;
using Common.Static.Utility.Decoding;
using Common.Static.Utility.Decoding.Model;
using Guqin.Info.MVC.Attributes;

namespace Guqin.Info.MVC.Controllers
{
    [CookieAuthAttribute]
    public abstract class AuthControllerBase : BaseController
    {
        public AuthControllerBase() : base()
        {           
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            HttpCookie authCookie = this.CurrentContext.Request.Cookies[KeyConst.USER_TOKEN_KEY];
            FormsAuthenticationTicket authTicket = Decoder.DecodeCookie(authCookie);
            AuthModel authModel = Decoder.DecodeAuthTicket(authTicket);
            authTicket = Encoder.EncodeAccessToken(authModel);
            this.CurrentContext.Response.Cookies.Add(new HttpCookie(
                KeyConst.USER_TOKEN_KEY, 
                FormsAuthentication.Encrypt(authTicket)));
        }

        private void ClearLogin(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Remove(KeyConst.USER_TOKEN_KEY);
        }

        private FormsAuthenticationTicket GenerateExpiryToken()
        {
            return new FormsAuthenticationTicket(
                   0,
                   "",
                   DateTime.Now,
                   DateTime.Now.AddDays(-1),
                   false,
                   "");
        }
    }
}