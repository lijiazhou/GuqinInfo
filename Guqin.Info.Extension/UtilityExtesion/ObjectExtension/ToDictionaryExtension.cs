using System;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Static.Extension.UtilityExtesion
{
    public static class ToDictionaryExtension
    {
        public static IDictionary<String, Object> ToDictionary(this object obj)
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            Type type = obj.GetType();
            List<PropertyInfo> pi = new List<PropertyInfo>(type.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            pi.ForEach(
                p => {
                    MethodInfo mi = p.GetGetMethod();
                    if (mi != null && mi.IsPublic)
                    {
                        Object value = mi.Invoke(obj, new Object[] { });
                        dict.Add(p.Name, value);
                    }
                });

            return dict;
        }
    }
}
