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
            string rawQuantity;
            string rawName;
            string rawPrice;

            if (GetProductRawValues(line, out rawQuantity, out rawName, out rawPrice))
            {
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
        /// Returns string product values from processed string
        /// </summary>
        /// <param name="line">Product string value</param>
        /// <param name="rawQuantity">Returns quantity value from string. If invalid value returns null</param>
        /// <param name="rawName">Returns name value from string. If invalid value returns null</param>
        /// <param name="rawPrice">Returns price value from string. If invalid value returns null</param>
        /// <returns></returns>
        public bool GetProductRawValues(string line, out string rawQuantity, out string rawName, out string rawPrice)
        {
            string regexPattern = "^([1-9]+) ([\\w\\s]*) at (\\d+.\\d{2})$";
            bool output = false;

            rawQuantity = rawName = rawPrice = null;

            MatchCollection matches = Regex.Matches(line, regexPattern);
            if (matches.Count >= 1)
            {
                rawQuantity = matches[0].Groups[1].Value;
                rawName = matches[0].Groups[2].Value;
                rawPrice = matches[0].Groups[3].Value;
                output = true;
            }
            return output;
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
