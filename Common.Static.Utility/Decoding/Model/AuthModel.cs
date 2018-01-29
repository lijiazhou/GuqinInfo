using System;
using System.Text.RegularExpressions;

namespace Common.Static.Utility.Decoding.Model
{
    public class AuthModel
    {
        private static String pattern { get { return @"^UserName:[\u4e00-\u9fa5A-Za-z0-9]+ Password:[a-zA-Z0-9]\w{5,17} ID:[1-9][0-9]* UserType:[A-Z]{5,10}$"; } }
        public String UserName { get; set; }
        public String Password { get; set; }
        public Int32 ID { get; set; }
        public String UserType { get; set; }
        public Boolean IsValid { private set; get; }
        

        public AuthModel(string token)
        {
            try
            {             
                if (!Regex.IsMatch(token, pattern))
                {
                    this.IsValid = false;
                    return;
                }

                String[] tokenSplits = token.Split(' ');
                this.UserName = tokenSplits[0].Split(':')[1];
                this.Password = tokenSplits[1].Split(':')[1];
                this.ID = Convert.ToInt32(tokenSplits[2].Split(':')[1]);
                this.UserType = tokenSplits[3].Split(':')[1];
                this.IsValid = true;
            } catch
            {
                this.IsValid = false;
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
                + nameof(this.UserType)
                + ":"
                + this.UserType;
            return rawToken;
        }
    }
}
