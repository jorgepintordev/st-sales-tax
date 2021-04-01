using SalesTax.BL.Taxes;
using SalesTax.Contracts.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SalesTax.BL.Builders
{
    /// <summary>
    /// Class to help build ShoppingCart
    /// </summary>
    public class ShoppingCartBuilder
    {
        private IProductAdapter _productAdapter;
        public ShoppingCartBuilder(IProductAdapter productAdapter)
        {
            _productAdapter = productAdapter;
        }

        /// <summary>
        /// Returns a new ShoppingCart object with the specified products
        /// </summary>
        /// <param name="rawProducts">Raw string array of products</param>
        /// <returns></returns>
        public ShoppingCart CreateShoppingCart(string[] rawProducts)
        {
            //validate not null parameter parameter
            if(rawProducts is null && rawProducts.Length == 0)
            {
                throw new ArgumentNullException("rawProdct", "parameter can't be null or empty");
            }

            List<Product> products = new List<Product>();

            foreach (string line in rawProducts)
            {
                try
                {
                    //Convert string to product
                    var product = _productAdapter.Process(line);

                    //validate if product already on list, add product or update quantity
                    if (products.Count(x => x.Name == product.Name && x.ShelfPrice == product.ShelfPrice) == 0)
                    {
                        products.Add(_productAdapter.Process(line));
                    }
                    else
                    {
                        products.Single(x => x.Name == product.Name && x.ShelfPrice == product.ShelfPrice).Quantity += product.Quantity;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return new ShoppingCart(products);
        }
    }
}
