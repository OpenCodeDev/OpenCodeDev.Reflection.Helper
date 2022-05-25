using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenCodeDev.Reflection.Helper
{
    public static class TypeExt
    {
        /// <summary>
        /// Get Public property by name
        /// </summary>
        public static PropertyInfo? GetPropertyPublic(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// Get Private/Internal non public property by name.
        /// </summary>
        public static PropertyInfo? GetPropertyPrivate(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Get public or non public property by name
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo? GetPropertyUnrest(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        /// <summary>
        /// Get public static prop by name
        /// </summary>
        public static PropertyInfo? GetPropertyStaticPublic(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Static | BindingFlags.Public);
        }

        /// <summary>
        /// Get non public static prop by name
        /// </summary>
        public static PropertyInfo? GetPropertyStaticPrivate(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Static | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Get Non Public and Public Static Prop info by name
        /// </summary>
        public static PropertyInfo? GetPropertyStatic(this Type? type, string name)
        {
            return type?.GetProperty(name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        }

    }
}
