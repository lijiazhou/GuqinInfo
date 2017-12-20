using Common.Static.Utility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Static.Utility.Decoding
{
    public class Decoder
    {  
        public static AuthModel DecodeAccessToken(string token)
        {
            return new AuthModel(token);
        }
    }
}
