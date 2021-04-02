using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL
{
    /// <summary>
    /// Class to handle print receipt process from a list of products
    /// </summary>
    public class ShoppingCart
    {
        private List<Product> _products;

        public ShoppingCart(List<Product> products)
        {
            _products = products;
        }

        /// <summary>
        /// Print receipt process
        /// </summary>
        /// <returns></returns>
        public string PrintReceipt()
        {
            //acumlate totals
            decimal total = 0;
            decimal tax = 0;

            StringBuilder output = new StringBuilder();
            //Print Products
            foreach(var product in _products)
            {
                tax += product.GetTotalTaxes(true);
                total += product.GetTotal();
                
                output.Append(PrintProduct(product) + Environment.NewLine);
            }

            //Print Sales Taxes
            output.Append($"Sales Taxes: {tax.ToString("0.00")}{Environment.NewLine}");


            //Print Total
            output.Append($"Total: {total.ToString("0.00")}");

            return output.ToString();
        }

        /// <summary>
        /// Print product details
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        private string PrintProduct(Product product)
        {
            string output;
            //If multiple quantity of a product show details
            if (product.Quantity == 1)
            {
                output = $"{product.Name}: {product.GetTotal()}";
            }
            else
            {
                output = $"{product.Name}: {product.GetTotal()} ({product.Quantity} @ {product.GetPrice()})";
            }

            return output;
        }
    }
}
