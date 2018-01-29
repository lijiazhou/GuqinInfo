using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Common.Static.Settings.Const;
using Common.Static.Utility.Decoding.Model;
using Common.Static.Utility.Decoding;
using System.Collections.Generic;

namespace Common.Static.Utility.Attributes
{
    public class CookieAuthAttribute : AuthorizeAttribute
    {
        private static Dictionary<String, IAuthCheck> checkDic = new Dictionary<string, IAuthCheck>();

        

        public static void RegisterAuthChecker(String key, IAuthCheck checker)
        {
            checkDic.Add(key, checker);
        }

        public CookieAuthAttribute() : base()
        {
        }

        public CookieAuthAttribute(params String[] keys) : this()
        {
            if(keys == null)
            {
                throw new ArgumentNullException("keys contains null value");
            }

            if (keys.Length == 0)
            {
                throw new InvalidOperationException("No checker has been registered");
            }

            if (checkDic.Keys.Count == 0)
            {
                throw new ArgumentException("keys contain no elements");
            }

            this.keys = keys.ToList();
            this.keys = this.keys.Intersect(checkDic.Keys).ToList();
            if (this.keys.Count == 0)
            {
                throw new ArgumentException("Unregistered check keys");
            }
        }

        private List<String> keys;

        private HttpCookieCollection httpCookies { get { return HttpContext.Current.Request.Cookies; } }

        public override void OnAuthorization(AuthorizationContext attributeContext)
        {
            base.OnAuthorization(attributeContext);
            this.ExecuteAuthValidation(attributeContext);
        }

        private void ExecuteAuthValidation(AuthorizationContext attributeContext)
        {
            if (!this.Check(attributeContext))
            {
                this.RedirectToLogin(attributeContext);
            }
        }

        private Boolean Check(AuthorizationContext attributeContext)
        {
            HttpCookie authCookie = this.httpCookies[KeyConst.USER_TOKEN_KEY];
            if (authCookie == null)
            {
                return false;
            }

            FormsAuthenticationTicket authTicket = Decoder.DecodeCookie(authCookie);
            AuthModel authModel = Decoder.DecodeAccessToken(authTicket.UserData);

            if (!this.ValidateToken(authTicket, authModel))
            {
                return false;
            }

            return this.RunAuthCheck(authModel);
        }

        public Boolean RunAuthCheck(AuthModel authModel)
        {
            if (this.keys == null)
                return true;

            Boolean result = true;

            for(int i = 0; result; i++)
            {
                result = checkDic[this.keys[i]].Check(authModel);
            }

            return result;
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
            new
            {
                controller = controllerName,
                action = actionName,
                returnUrl = url
            });
        }

    }
}