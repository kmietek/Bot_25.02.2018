using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Enums;
using Factories.Facebook.Interfaces;


namespace Factories.Helpers
{
    public static class AbstractHelpers
    {
        static AbstractHelpers()
        {
            var a = Assembly.GetAssembly(typeof(MainAbstractClass)).GetTypes();
            var b = a.Where(m => m.BaseType == typeof(MainAbstractClass)).ToList();

            foreach (var item in b)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var res = assembly.CreateInstance(item.FullName) as MainAbstractClass;
                FacebookPageClassesInstance.Add(item.Name.ToLower(), res);
            }
        }

        private static Dictionary<string, MainAbstractClass> FacebookPageClassesInstance = new Dictionary<string, MainAbstractClass>();

        public static MainAbstractClass GetFacebookPageClassesInstance(EnumPages enuma)
        {
            return FacebookPageClassesInstance[enuma.ToString().ToLower()];
        }











        public static Dictionary<string,object> GetClassesFromAbstractClass<T>() where T:class 
        {
            Dictionary<string,object> q = new Dictionary<string, object>();

            var a = Assembly.GetAssembly(typeof(T)).GetTypes();
            var b = a.Where(m => m.BaseType == typeof(T)).ToList();

            foreach (var item in b)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                var res = assembly.CreateInstance(item.FullName) as T;
                q.Add(item.Name.ToLower(), res);
            }

            return q;
        }

    }
}