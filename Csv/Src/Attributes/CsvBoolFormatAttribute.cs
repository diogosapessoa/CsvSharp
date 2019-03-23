using CsvSharp.Iterfaces;
using System;

namespace CsvSharp.Attributes
{
    /// <summary>
    /// To be added.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvBoolFormatAttribute : Attribute, IConvertFormat
    {
        /// <summary>
        /// To be added.
        /// </summary>
        public string True { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        public string False { get; }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="true"></param>
        /// <param name="false"></param>
        public CsvBoolFormatAttribute(string @true, string @false)
        {
            True = @true;
            False = @false;
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public object Convert(string value, IFormatProvider provider)
        {
            if (value == True)
            {
                return true;
            }
            else if (value == False)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ConvertBack(object value, IFormatProvider provider)
        {
            if (value is bool valueBool)
            {
                return valueBool ? True : False;
            }
            return string.Empty;
        }
    }
}
