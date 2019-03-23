using CsvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CsvSharp
{
    /// <summary>
    /// To be added.
    /// </summary>
    public static class CsvConvert
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Serialize<T>(IEnumerable<T> collection, CultureInfo cultureInfo, string separator = ";") where T : class
        {
            return string.Join(Environment.NewLine, collection.Select(o => o.CsvLineFromObject(cultureInfo, separator)));
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csv"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEnumerable<T> Deserialize<T>(IEnumerable<string> csv, CultureInfo cultureInfo, string separator = ";") where T : class, new()
        {
            return csv.Select(l => l.CsvObjectFromLine<T>(cultureInfo, separator));
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csv"></param>
        /// <param name="cultureInfo"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static IEnumerable<T> Deserialize<T>(string csv, CultureInfo cultureInfo, string separator = ";") where T : class, new()
        {
            return Deserialize<T>(csv.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries), cultureInfo, separator);
        }
    }
}
