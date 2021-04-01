using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Contracts.BL
{
    public interface ITax
    {
        /// <summary>
        /// Calculate tax based on the amount
        /// </summary>
        /// <param name="amount">Amount from which the tax will be calculated</param>
        /// <returns></returns>
        decimal CalculateTax(decimal amount);
    }
}
