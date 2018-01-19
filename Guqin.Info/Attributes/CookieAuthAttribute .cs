using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.Static.Settings.Const;
using Common.Static.Utility.Decoding.Model;
using Common.Static.Utility.Decoding;

namespace Guqin.Info.MVC.Attributes
{
    public class CookieAuthAttribute : AuthorizeAttribute
    {
        private HttpCookieCollection httpCookies { get { return HttpContext.Current.Request.Cookies; } }

        public override void OnAuthorization(AuthorizationContext attributeContext)
        {
            base.OnAuthorization(attributeContext);
            this.ExecuteAuthValidation(attributeContext);
        }

        private void ExecuteAuthValidation(AuthorizationContext attributeContext)
        {
            HttpCookie authCookie = this.httpCookies[KeyConst.USER_TOKEN_KEY];
            if (authCookie == null)
            {
                this.RedirectToLogin(attributeContext);
                return;
            }

            FormsAuthenticationTicket authTicket = Decoder.DecodeCookie(authCookie);
            AuthModel authModel = Decoder.DecodeAccessToken(authTicket.UserData);

            if (!this.ValidateToken(authTicket, authModel))
            {
                this.RedirectToLogin(attributeContext);
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

        private void RedirectToLogin(AuthorizationContext attributeContext)
        {
            String url = attributeContext.HttpContext.Request.Url.ToString();
            attributeContext.Result = new RedirectToRouteResult(this.CreateRouteValueDictionary("Account", "Login", url));
        }

        private RouteValueDictionary CreateRouteValueDictionary(String controllerName, String actionName, String url)
        {
            return new RouteValueDictionary(
            new {
                controller = controllerName,
                action = actionName,
                returnUrl = url
            });
        }

    }
}