using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Common.Static.Extension.UtilityExtesion
{
    public static class ClassExtension
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

        public static String GetClassName(this Object obj)
        {
            return obj.GetType().Name;
        }

        public static String GetNameSpace(this Object obj)
        {
            return obj.GetType().Namespace;
        }

        public static String GetFullName(this Object obj)
        {
            return obj.GetType().FullName;
        }

        public static String GetParentName(this Object obj)
        {
            return obj.GetType().BaseType.Name;
        }

        public static String GetParentNameSpace(this Object obj)
        {
            return obj.GetType().BaseType.Namespace;
        }

        public static String GetParentFullName(this Object obj)
        {
            return obj.GetType().BaseType.FullName;
        }

        public static String[] GetInterfaces(this Object obj)
        {
            Type[] types = GetInterfaceTypes(obj);
            if (types.Count() == 0)
                return null;

            return types.Select(x => x.Name).ToArray();
        }

        public static String[] GetInterfaceNamespaces(this Object obj)
        {
            Type[] types = GetInterfaceTypes(obj);
            if (types.Count() == 0)
                return null;

            return types.Select(x => x.Namespace).ToArray();
        }

        public static String[] GetInterfaceNameSpaces(this Object obj)
        {
            Type[] types = GetInterfaceTypes(obj);
            if (types.Count() == 0)
                return null;

            return types.Select(x => x.FullName).ToArray();
        }

        private static Type[] GetInterfaceTypes(Object obj)
        {
            return obj.GetType().GetInterfaces();
        }
    }
}
