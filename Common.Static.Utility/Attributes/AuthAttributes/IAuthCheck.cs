using System;
using Common.Static.Utility.Decoding.Model;

namespace Common.Static.Utility.Attributes
{
    public interface IAuthCheck
    {
        Boolean Check(AuthModel authModel);
    }
}
