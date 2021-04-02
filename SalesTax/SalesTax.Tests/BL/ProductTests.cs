using SalesTax.BL;
using SalesTax.BL.Taxes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesTax.Tests.BL
{
    public class ProductTests
    {
        /// <summary>
        /// Test to validate Product.GetTotal
        /// </summary>
        [Theory]
        [InlineData(12.49, false, false, 12.49)]    //test for product without tax
        [InlineData(14.99, true, false, 16.49)]     //test for product with sales tax only
        [InlineData(10.00, false, true, 10.50)]     //test for product with import tax only
        [InlineData(47.50, true, true, 54.65)]      //test for product with all taxes
        public void GetTotal_ShouldWork(decimal price, bool salesTax, bool imporTax, decimal expected )
        {
            //arrange
            Product _sut = new Product(new NoTax(), new NoTax());
            _sut.Quantity = 1;
            _sut.ShelfPrice = price;
            if(salesTax)
            {
                _sut.SetSaleTax(Tax.CreateSaleTax());
            }

            if(imporTax)
            {
                _sut.SetImportTax(Tax.CreateImportTax());
            }

            //act
            var actual = _sut.GetTotal();

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
