using Common.Static.Utility.Decoding.Model;
using System;
using System.Web.Security;

namespace Common.Static.Utility.Decoding
{
    public class Encoder
    {
        public static FormsAuthenticationTicket EncodeAccessToken(AuthModel authModel)
        {
            return new FormsAuthenticationTicket(
                authModel.ID,
                authModel.UserName,
                DateTime.Now,
                DateTime.Now.AddDays(1),
                false,
                authModel.ToToken());
        } 
    }
}
