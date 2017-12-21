using Common.Static.Utility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Common.Static.Utility.Decoding
{
    public partial class Decoder
    {  
        public static AuthModel DecodeAccessToken(string token)
        {
            return new AuthModel(token);
        }

        public static FormsAuthenticationTicket DecodeCookie(HttpCookie httpCookie)
        {
            return FormsAuthentication.Decrypt(httpCookie.Value);
        }

        public static AuthModel DecodeAuthTicket(FormsAuthenticationTicket authTicket)
        {
            return DecodeAccessToken(authTicket.UserData);
        }
    }
}
