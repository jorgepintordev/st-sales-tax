using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL
{
    /// <summary>
    /// Class to handle Product behaviour
    /// </summary>
    public class Product
    {
        //private interfaces for tax handling
        private ITax _saleTax;
        private ITax _importTax;

        //public product properties
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal ShelfPrice { get; set; }

        public Product(ITax saleTax, ITax importTax)
        {
            _saleTax = saleTax;
            _importTax = importTax;
        }

        /// <summary>
        /// Set tax class to handle SalesTaxes
        /// </summary>
        /// <param name="saleTax">Object of class implementing ITax interface</param>
        /// <returns></returns>
        public Product SetSaleTax(ITax saleTax)
        {
            _saleTax = saleTax;
            return this;
        }

        /// <summary>
        /// Set tax class to handle ImportTaxes
        /// </summary>
        /// <param name="importTax">Object of class implementing ITax interface</param>
        /// <returns></returns>
        public Product SetImportTax(ITax importTax)
        {
            _importTax = importTax;
            return this;
        }

        /// <summary>
        /// Calculate the final price. ShelfPrice + ImportTax
        /// </summary>
        /// <returns></returns>
        public decimal GetPrice()
        {
            var price = ShelfPrice + GetImportTax();
            return price;
        }

        /// <summary>
        /// Calculate the import tax.
        /// </summary>
        /// <returns></returns>
        public decimal GetImportTax()
        {
            return _importTax.CalculateTax(ShelfPrice);
        }

        /// <summary>
        /// Calculate the sale tax.
        /// </summary>
        /// <returns></returns>
        public decimal GetSaleTax()
        {
            return _saleTax.CalculateTax(ShelfPrice);
        }

        /// <summary>
        /// Calculate the total amount of taxes
        /// </summary>
        /// <param name="multiplyQuantity">Allow return of total amount of taxes multiplied by quantity. Default value false</param>
        /// <returns></returns>
        public decimal GetTotalTaxes(bool multiplyQuantity = false)
        {
            decimal output = GetImportTax() + GetSaleTax();
            if (multiplyQuantity)
            {
                output = Quantity * output;
            }
            return output;
        }

        /// <summary>
        /// Calculate the total for the product
        /// </summary>
        /// <returns></returns>
        public decimal GetTotal()
        {
            decimal output = ShelfPrice + GetTotalTaxes();
            output = Quantity * output;

            return output;
        }

        /// <summary>
        /// Returns class name for SaleTax interface. For unit testing
        /// </summary>
        /// <returns></returns>
        public string GetSaleTaxType()
        {
            return _saleTax.GetType().Name;
        }

        /// <summary>
        /// Returns class name for ImportTax interface. For unit testing
        /// </summary>
        /// <returns></returns>
        public string GetImportTaxType()
        {
            return _importTax.GetType().Name;
        }
    }
}
