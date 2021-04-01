using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL.Taxes
{
    /// <summary>
    /// No tax apply. Implements ITax interface
    /// </summary>
    public class NoTax : ITax
    {
        /// <summary>
        /// Returns 0, no tax apply
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal CalculateTax(decimal amount)
        {
            return 0.0m;
        }
    }
}
