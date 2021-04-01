using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL.Taxes
{
    /// <summary>
    /// Generic tax class. Implements ITax interface
    /// </summary>
    public class Tax : ITax
    {
        private decimal _taxRate = 0;

        /// <summary>
        /// Create a tax object (Private to minimize errors on creation)
        /// </summary>
        /// <param name="taxRate">Tax rate to calculate amount</param>
        private Tax(decimal taxRate)
        {
            _taxRate = taxRate;
        }

        /// <summary>
        /// Creates a tax object with 5% rate (Import Duty)
        /// </summary>
        /// <returns></returns>
        public static Tax CreateImportTax()
        {
            return new Tax(0.05M);
        }

        /// <summary>
        /// Creates a tax object with 10% rate (Sales Tax)
        /// </summary>
        /// <returns></returns>
        public static Tax CreateSaleTax()
        {
            return new Tax(0.10M);
        }

        /// <summary>
        /// Calculate tax based on the tax rate
        /// </summary>
        /// <param name="amount">Amount from which the tax will be calculated</param>
        /// <returns></returns>
        public decimal CalculateTax(decimal amount)
        {
            return Utils.RoundUp(amount * _taxRate);
        }
    }
}
