using SalesTax.BL.Builders;
using SalesTax.BL.Taxes;
using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SalesTax.BL
{
    /// <summary>
    /// Class to help convert from string to product. Implements IProductAdapter interface
    /// </summary>
    public class ProductAdapter : IProductAdapter
    {
        //private interfaces for tax handling
        private ITax _saleTax;
        private ITax _importTax;
        //private interfaces for taxExceptions handling
        private ITaxExceptions _taxExceptions;
        public ProductAdapter(ITax saleTax, ITax importTax, ITaxExceptions taxExceptions)
        {
            _saleTax = saleTax;
            _importTax = importTax;
            _taxExceptions = taxExceptions;
        }

        /// <summary>
        /// Process to create Product object from string value
        /// </summary>
        /// <param name="line">Product string value</param>
        /// <returns></returns>
        public Product Process(string line)
        {
            string regexPattern = "(\\d+) ([\\w\\s]* )at (\\d+.\\d{2})";

            MatchCollection matches = Regex.Matches(line, regexPattern);


            if (matches.Count >= 1)
            {
                string rawQuantity = matches[0].Groups[1].Value;
                string rawName = matches[0].Groups[2].Value.Trim();
                string rawPrice = matches[0].Groups[3].Value;

                if (int.TryParse(rawQuantity, out int quantity) && decimal.TryParse(rawPrice, out decimal price))
                {
                    Product output = ProductBuilder.Create();
                    output.Name = rawName;
                    output.Quantity = quantity;
                    output.ShelfPrice = price;

                    if (IsImported(rawName))
                    {
                        output.SetImportTax(_importTax);
                    }

                    if (_taxExceptions.IsTaxApply(rawName))
                    {
                        output.SetSaleTax(_saleTax);
                    }

                    return output;
                }
            }

            throw new FormatException("Product line format not valid");
        }

        /// <summary>
        /// Validate if is imported product based on product name
        /// </summary>
        /// <param name="value">Product name</param>
        /// <returns></returns>
        public bool IsImported(string value)
        {
            return value.StartsWith("Imported");
        }
    }
}
