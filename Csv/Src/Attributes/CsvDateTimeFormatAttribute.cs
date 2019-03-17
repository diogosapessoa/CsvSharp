using CsvNet.Iterfaces;
using System;

namespace CsvNet.Attributes
{
    /// <summary>
    /// To be added.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvDateTimeFormatAttribute : Attribute, IConvertFormat
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public string Format { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="format"></param>
        public CsvDateTimeFormatAttribute(string format)
        {
            Format = format;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public object Convert(string value, IFormatProvider provider)
        {
            return DateTime.ParseExact(value, Format, provider);
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ConvertBack(object value, IFormatProvider provider)
        {
            if (value is IFormattable formattable)
            {
                return formattable.ToString(Format, provider);
            }

            return string.Empty;
        }
    }
}
