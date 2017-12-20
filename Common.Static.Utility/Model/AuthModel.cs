using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Static.Utility.Model
{
    public class AuthModel
    {
        private static String pattern { get { return @"^UserName:[\u4e00-\u9fa5A-Za-z0-9]+ Password:[a-zA-Z0-9]\w{5,17} ID:[1-9][0-9]* LoginTime:[1-9][0-9]+$"; } }

        public String UserName { get; set; }
        public String Password { get; set; }
        public Int32 ID { get; set; }
        public DateTime LoginTime { get; set; }

        public Boolean IsValid { get { return this.isValid; } }

        private Boolean isValid;


        public AuthModel(string token)
        {
            try
            {
                String rawToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                if (!Regex.IsMatch(rawToken, pattern))
                {
                    this.isValid = false;
                    return;
                }

                String[] tokenSplits = rawToken.Split(' ');
                this.UserName = tokenSplits[0].Split(':')[1];
                this.Password = tokenSplits[1].Split(':')[1];
                this.ID = Convert.ToInt32(tokenSplits[2].Split(':')[1]);
                this.LoginTime = new DateTime(0).AddMilliseconds(Convert.ToInt32(tokenSplits[3].Split(':')[1]));
                this.isValid = true;
            } catch
            {
                this.isValid = false;
            }
        }

        public string ToToken()
        {
            String rawToken = nameof(this.UserName)
                + ":"
                + this.UserName
                + " "
                + nameof(this.Password)
                + ":"
                + this.Password
                + " "
                + nameof(this.ID)
                + ":"
                + this.ID
                + " "
                + nameof(this.LoginTime)
                + ":"
                + this.LoginTime.Millisecond;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(rawToken));
        }
    }
}
