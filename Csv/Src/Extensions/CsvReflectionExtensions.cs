using CsvSharp.Iterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CsvSharp.Extensions
{
    /// <summary>
    /// To be added.
    /// </summary>
    public static class CsvReflectionExtensions
    {
        /// <summary>
        /// to be added.
        /// </summary>
        public const BindingFlags BindingFlagsConstraint = BindingFlags.Public | BindingFlags.Instance;

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="obj"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public static object GetValue(this PropertyInfo propertyInfo, object obj, CultureInfo cultureInfo)
        {
            return propertyInfo.GetValue(obj, BindingFlagsConstraint, null, null, cultureInfo);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        public static void SetValue(this PropertyInfo propertyInfo, object obj, object value, CultureInfo cultureInfo)
        {
            propertyInfo.SetValue(obj, value, BindingFlagsConstraint, null, null, cultureInfo);
        }

        /// <summary>
        /// To be added.
        /// To be added.
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static IConvertFormat GetFormatter(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(true).FirstOrDefault(a => a is IConvertFormat) as IConvertFormat;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="line"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static T CsvObjectFromLine<T>(this string line, CultureInfo cultureInfo, string separator) where T : class, new()
        {
            var words = line.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);

            var result = new T();

            var properties = result
                .GetType()
                .GetProperties(BindingFlagsConstraint);

            for (var index = 0; index < properties.Length; index++)
            {
                var prop = properties[index];

                if (!prop.CanWrite)
                {
                    continue;
                }

                var value = words[index];

                var formatter = prop.GetFormatter();

                if (formatter == null)
                {
                    prop.SetValue(result, Convert.ChangeType(value, prop.PropertyType, cultureInfo), cultureInfo);
                }
                else
                {
                    prop.SetValue(result, formatter.Convert(value, cultureInfo), cultureInfo);
                }
            }

            return result;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string CsvLineFromObject<T>(this T obj, CultureInfo cultureInfo, string separator) where T : class
        {
            var result = new List<string>();

            foreach (var prop in obj.GetType().GetProperties(BindingFlagsConstraint))
            {
                var value = prop.GetValue(obj, cultureInfo);

                var formatter = prop.GetFormatter();

                if (formatter == null)
                {
                    result.Add(value is IConvertible ? (value as IConvertible).ToString(cultureInfo) : value.ToString());
                }
                else
                {
                    result.Add(formatter.ConvertBack(value, cultureInfo));
                }
            }

            return string.Join(separator, result);
        }
    }
}
