using SalesTax.BL;
using SalesTax.BL.Builders;
using SalesTax.BL.Taxes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesTax.Tests
{
    public class SalesTaxTests
    {
        /// <summary>
        /// Test for input 1
        /// </summary>
        [Fact]
        public void TestSample1_ShouldWork()
        {
            //arrange
            var shoppingCart = new ShoppingCartBuilder(new ProductAdapter(Tax.CreateSaleTax(), Tax.CreateImportTax(), new TaxExceptions()))
                        .CreateShoppingCart(SampleData.Input1);
            string expected = "Book: 24.98 (2 @ 12.49)" + Environment.NewLine +
                "Music CD: 16.49" + Environment.NewLine +
                "Chocolate bar: 0.85" + Environment.NewLine +
                "Sales Taxes: 1.50" + Environment.NewLine +
                "Total: 42.32";


            //act
            var actual = shoppingCart.PrintReceipt();

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test for input 2
        /// </summary>
        [Fact]
        public void TestSample2_ShouldWork()
        {
            //arrange
            var shoppingCart = new ShoppingCartBuilder(new ProductAdapter(Tax.CreateSaleTax(), Tax.CreateImportTax(), new TaxExceptions()))
                        .CreateShoppingCart(SampleData.Input2);
            string expected = "Imported box of chocolates: 10.50" + Environment.NewLine +
                "Imported bottle of perfume: 54.65" + Environment.NewLine +
                "Sales Taxes: 7.65" + Environment.NewLine +
                "Total: 65.15";


            //act
            var actual = shoppingCart.PrintReceipt();

            //assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Test for input 3
        /// </summary>
        [Fact]
        public void TestSample3_ShouldWork()
        {
            //arrange
            var shoppingCart = new ShoppingCartBuilder(new ProductAdapter(Tax.CreateSaleTax(), Tax.CreateImportTax(), new TaxExceptions()))
                        .CreateShoppingCart(SampleData.Input3);
            string expected = "Imported bottle of perfume: 32.19" + Environment.NewLine +
                "Bottle of perfume: 20.89" + Environment.NewLine +
                "Packet of headache pills: 9.75" + Environment.NewLine +
                "Imported box of chocolates: 23.70 (2 @ 11.85)" + Environment.NewLine +
                "Sales Taxes: 7.30" + Environment.NewLine +
                "Total: 86.53";


            //act
            var actual = shoppingCart.PrintReceipt();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
