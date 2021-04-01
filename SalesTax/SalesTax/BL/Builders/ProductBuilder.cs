using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.BL.Builders
{
    /// <summary>
    /// Class to help build default Product without tax
    /// </summary>
    public static class ProductBuilder
    {
        /// <summary>
        /// Returns a new Product object
        /// </summary>
        /// <returns></returns>
        public static Product Create()
        {
            return new Product(new Taxes.NoTax(), new Taxes.NoTax());
        }
    }
}
