using System;
using System.Web.Security;

namespace Common.Static.Settings.Const
{
    public sealed partial class KeyConst
    {
        public static String USER_TOKEN_KEY { get { return FormsAuthentication.FormsCookieName; } }

    }
}
