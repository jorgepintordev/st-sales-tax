using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL.Taxes
{
    /// <summary>
    /// Class to handle Products with tax exception. Implements ITaxExceptions interface
    /// </summary>
    public class TaxExceptions : ITaxExceptions
    {
        //defalt exceptions list
        public List<string> Exceptions = new List<string>
        {
            "book", "books",
            "chocolate", "chocolates",
            "pill", "pills", "medicine"
        };

        /// <summary>
        /// Validate if Tax apply based on product name
        /// </summary>
        /// <param name="value">Product name</param>
        /// <returns></returns>
        public bool IsTaxApply(string value)
        {
            foreach(string exception in Exceptions)
            {
                if(value.ToLower().Contains(exception))
                {
                    return false;
                }
            }
            return true;
        }        
    }
}
