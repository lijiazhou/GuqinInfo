using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Common.Static.Extension.UtilityExtesion
{
    public static class MethodExtension
    {
        public static String GetMethodName(this Object obj)
        {
            MethodBase method = new StackFrame(1).GetMethod();
            //PropertyInfo property = (
            //from p in method.DeclaringType.GetProperties(
            //BindingFlags.Instance |
            //BindingFlags.Static |
            //BindingFlags.Public |
            //BindingFlags.NonPublic)
            //where p.GetGetMethod(true) == method || p.GetSetMethod(true) == method
            //select p).FirstOrDefault();
            //return property == null ? method.Name : property.Name;
            return method.Name;
        }
    }
}
