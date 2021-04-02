using SalesTax.BL;
using SalesTax.BL.Taxes;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesTax.Tests.BL
{
    public class ProductAdapterTests
    {
        ProductAdapter _sut = new ProductAdapter(Tax.CreateSaleTax(), Tax.CreateImportTax(), new TaxExceptions());
        
        /// <summary>
        /// Test to validate ProdctAdapter.Process
        /// </summary>
        [Theory]
        [InlineData("1 Book at 12.49", "Book", 1, 12.49, "NoTax", "NoTax")]                                             //test for product without tax
        [InlineData("1 Music CD at 14.99", "Music CD", 1, 14.99, "Tax", "NoTax")]                                       //test for product with sales tax only
        [InlineData("1 Imported box of chocolates at 10.00", "Imported box of chocolates", 1, 10.00, "NoTax", "Tax")]   //test for product with import tax only
        [InlineData("1 Imported bottle of perfume at 47.50", "Imported bottle of perfume", 1, 47.50, "Tax", "Tax")]     //test for product with all taxes
        public void Process_ShouldWork(string testLine, string expectedName, int expectedQuantity, decimal expectedPrice, string expectedSaleTaxClass, string expectedImportTaxClass)
        {   
            //act
            var actual = _sut.Process(testLine);
            var actualSaleTaxClass = actual.GetSaleTaxType();
            var actualImportTaxClass = actual.GetImportTaxType();

            //assert
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedQuantity, actual.Quantity);
            Assert.Equal(expectedPrice, actual.ShelfPrice);
            Assert.Equal(expectedSaleTaxClass, actualSaleTaxClass);
            Assert.Equal(expectedImportTaxClass, actualImportTaxClass);
        }

        /// <summary>
        /// Test to validate ProdctAdapter.Process when using invalid data format
        /// </summary>
        [Theory]
        [InlineData("0 Book at 12.49")]
        [InlineData("")]
        public void Process_ShouldFail(string testLine)
        {
            //act & assert
            Assert.Throws<FormatException>(() => _sut.Process(testLine));
        }

        /// <summary>
        /// Test to validate ProdctAdapter.GetProductRawValues
        /// </summary>
        [Fact]
        public void GetProductRawValues_ShouldWork()
        {
            //arrange
            string testLine = "1 Book at 12.49";
            bool expected = true;
            string expectedQuantity = "1";
            string expectedName = "Book";
            string expectedPrice = "12.49";

            //act
            bool actual =_sut.GetProductRawValues(testLine, out string actualQuantity, out string actualName, out string actualPrice);

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedQuantity, actualQuantity);
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedPrice, actualPrice);
        }

        /// <summary>
        /// Test to validate ProdctAdapter.GetProductRawValues when using invalid data format
        /// </summary>
        [Theory]
        [InlineData("0 Book at 10.00", false)]
        [InlineData("-1 Book at 10.00", false)]
        [InlineData("1 Book at -10.00", false)]
        [InlineData("", false)]
        [InlineData("hjkdhas 10.20", false)]
        public void GetProductRawValues_ShouldFail(string testLine, bool expected)
        {
            //act
            bool actual = _sut.GetProductRawValues(testLine, out string actualQuantity, out string actualName, out string actualPrice);

            //assert
            Assert.Equal(expected, actual);
        }
    }
}
