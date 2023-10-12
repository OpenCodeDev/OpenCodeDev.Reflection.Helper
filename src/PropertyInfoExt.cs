using System.Collections.Generic;
using System.Reflection;

namespace OpenCodeDev.Reflection.Helper
{
    public static class PropertyInfoExt
    {
        public static bool IsBool(this PropertyInfo prop) { return prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?); }
        public static bool IsString(this PropertyInfo prop) { return prop.PropertyType == typeof(String); }
        public static bool IsFloat(this PropertyInfo prop) { return prop.PropertyType == typeof(float) || prop.PropertyType == typeof(float?); }
        public static bool IsDecimal(this PropertyInfo prop) { return prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?); }
        public static bool IsDouble(this PropertyInfo prop) { return prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?); }
        public static bool IsInt(this PropertyInfo prop) { return prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?); }
        public static bool IsLong(this PropertyInfo prop) { return prop.PropertyType == typeof(long) || prop.PropertyType == typeof(long?); }
        public static bool IsShort(this PropertyInfo prop) { return prop.PropertyType == typeof(short) || prop.PropertyType == typeof(short?); }
        public static bool IsDateTime(this PropertyInfo prop) { return prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?); }


        /// <summary>
        /// Check if type is Class Object
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="ignoreGeneric">True: will not System.Type and Generic Types like List, Dictionary</param>
        /// <returns></returns>
        public static bool IsObject(this PropertyInfo prop, bool ignoreGeneric = false) { 
            return !ignoreGeneric ?
                prop.PropertyType.IsClass :
                prop.PropertyType.IsClass && !prop.PropertyType.IsPrimitive && 
                !prop.PropertyType.IsGenericType && !prop.IsString(); 
        }

        public static bool IsArray(this PropertyInfo prop) { return prop.PropertyType.IsArray; }



        /// <summary>
        /// Check if prop is a List
        /// </summary>
        /// <param name="ignoreGeneric">True: Ignore List of List, List of int so on.... only check for List of ClassObject</param>
        public static bool IsList(this PropertyInfo prop, bool ignoreGeneric = false)
        {
            return !ignoreGeneric ? 
                prop.PropertyType.IsClass && prop.IsGeneric(typeof(List<>)) :
                (prop.IsList() && !prop.GetListType().IsPrimitive && !prop.GetListType().IsGenericType && !prop.IsString());
        }

        public static bool IsListType<T>(this PropertyInfo prop)
        {
            return prop.GetListType() == typeof(T);
        }

        /// <summary>
        /// Return type argument in list List of Type
        /// </summary>
        public static Type? GetListType(this PropertyInfo prop)
        { return !prop.IsList() ? null : prop.PropertyType.GetGenericArguments()[0]; }

        public static Type? GetTypeArgZero(this PropertyInfo prop)
        { return !prop.IsList() ? null : prop.PropertyType.GetGenericArguments()[0]; }

        public static bool Is<T>(this PropertyInfo prop) { return prop.Is(typeof(T)); }



        /// <summary>
        /// Check if prop is generic to X used to check list prop.IsGeneric(typeof(List<>))
        /// </summary>
        public static bool IsGeneric(this PropertyInfo prop, Type type) { 
            return 
                prop.PropertyType.IsGenericType && 
                prop.PropertyType.GetGenericTypeDefinition() == type; 
        }

        public static bool Is(this PropertyInfo prop, Type type) {
            

            return (prop.PropertyType == type) || Nullable.GetUnderlyingType(prop.PropertyType) == type; 
        }

        /// <summary>
        /// Check if an attribute exist on a property return false if prop null and if not found or if attribute == null
        /// </summary>
        public static bool HasAttribute<T>(this PropertyInfo prop) { return prop == null ? false : prop.GetCustomAttributes(typeof(T)).Count() >= 2 || prop.GetCustomAttribute(typeof(T)) != null; }
    }
}