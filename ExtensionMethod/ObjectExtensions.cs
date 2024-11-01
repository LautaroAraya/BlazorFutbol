using System;
using System.Reflection;

namespace BlazorFutbol.ExtensionMethod
{


    public static class ObjectExtensions
    {
        public static void CopyPropertiesTo<T>(this T source, T destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Objeto de origen o destino son nulos");
            }

            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(destination, value, null);
                }
            }
        }
        public static string PropertiesToString<T>(this T source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Type type = typeof(T);

            string stringReturn=string.Empty;

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object? value = property.GetValue(source, null);
                    stringReturn += $"{property.Name}={value?.ToString()??"null"}{Environment.NewLine}";
                }
            }
            return stringReturn;
        }
    }
}
