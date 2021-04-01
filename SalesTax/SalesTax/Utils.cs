using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    /// <summary>
    /// Utils class
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Round Up to nearest 5 cents
        /// </summary>
        /// <param name="amount">Amount to round up</param>
        /// <returns></returns>
        public static decimal RoundUp(decimal amount)
        {
            //0.05 is 1/20
            return Math.Ceiling(amount * 20) / 20;
        }
    }
}
