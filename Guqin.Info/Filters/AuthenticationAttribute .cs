using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.Static.Settings.Const;
using Common.Static.Utility.Model;
using Common.Static.Utility.Decoding;

namespace Guqin.Info.MVC.Filters
{
    public class AuthenticationAttribute : AuthorizeAttribute
    {
        private HttpCookieCollection httpCookies { get { return HttpContext.Current.Request.Cookies; } }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            this.ExecuteAuthValidation(filterContext);
        }

        private void ExecuteAuthValidation(AuthorizationContext filterContext)
        {
            HttpCookie authCookie = this.httpCookies[KeyConst.USER_TOKEN_KEY];
            if (authCookie == null)
            {
                this.RedirectToLogin(filterContext);
                return;
            }

            FormsAuthenticationTicket authTicket = Decoder.DecodeCookie(authCookie);
            AuthModel authModel = Decoder.DecodeAccessToken(authTicket.UserData);

            if (!this.ValidateToken(authTicket, authModel))
            {
                this.RedirectToLogin(filterContext);
                return;
            }
           
            //database check
        }

        private Boolean ValidateToken(FormsAuthenticationTicket authTicket, AuthModel authModel)
        {
            if (authTicket.Expired)
            {
                return false;
            }

            if (!authModel.IsValid)
            {
                return false;
            }

            return true;
        }

        private void RedirectToLogin(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                    "Login",
                                    new RouteValueDictionary {
                                        {
                                            "from",
                                            filterContext.HttpContext.Request.Url.ToString()
                                        } });
        }

       
    }
}