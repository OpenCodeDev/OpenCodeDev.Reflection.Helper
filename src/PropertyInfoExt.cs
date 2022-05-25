using System.Reflection;

namespace OpenCodeDev.Reflection.Helper
{
    public static class PropertyInfoExt
    {
        public static bool IsBool(this PropertyInfo prop) { return prop.PropertyType == typeof(bool); }
        public static bool IsString(this PropertyInfo prop) { return prop.PropertyType == typeof(string); }
        public static bool IsFloat(this PropertyInfo prop) { return prop.PropertyType == typeof(float); }
        public static bool IsDecimal(this PropertyInfo prop) { return prop.PropertyType == typeof(decimal); }
        public static bool IsDouble(this PropertyInfo prop) { return prop.PropertyType == typeof(double); }
        public static bool IsInt(this PropertyInfo prop) { return prop.PropertyType == typeof(int); }
        public static bool IsLong(this PropertyInfo prop) { return prop.PropertyType == typeof(long); }
        public static bool IsShort(this PropertyInfo prop) { return prop.PropertyType == typeof(short); }
        public static bool IsObject(this PropertyInfo prop) { return prop.PropertyType == typeof(object); }
        public static bool IsDateTime(this PropertyInfo prop) { return prop.PropertyType == typeof(DateTime); }
        public static bool Is<T>(this PropertyInfo prop) { return prop.PropertyType == typeof(T); }
    }
}