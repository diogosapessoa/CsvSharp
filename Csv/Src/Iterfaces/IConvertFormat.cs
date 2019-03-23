using System;

namespace CsvSharp.Iterfaces
{
    /// <summary>
    /// To be added.
    /// </summary>
    public interface IConvertFormat
    {
        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        object Convert(string value, IFormatProvider provider);

        /// <summary>
        /// To be added.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        string ConvertBack(object value, IFormatProvider provider);
    }
}
