using SalesTax.BL;
using SalesTax.BL.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    /// <summary>
    /// Sample data for testing
    /// </summary>
    public class SampleData
    {
        public static string[] InputWrong
        {
            get
            {
                return new string[] {
                    "sa Book at 12.49",
                    "1 Book at 12.49",
                    "1 Music CD at 14.99",
                    "1 Chocolate bar at 0.85"
                };
            }
        }

        public static string[] Input1 { get { 
                return new string[] {
                    "1 Book at 12.49",
                    "1 Book at 12.49",
                    "1 Music CD at 14.99",
                    "1 Chocolate bar at 0.85"
                }; 
            } }

        public static string[] Input2
        {
            get
            {
                return new string[] {
                    "1 Imported box of chocolates at 10.00",
                    "1 Imported bottle of perfume at 47.50"
                };
            }
        }

        public static string[] Input3
        {
            get
            {
                return new string[] {
                    "1 Imported bottle of perfume at 27.99",
                    "1 Bottle of perfume at 18.99",
                    "1 Packet of headache pills at 9.75",
                    "1 Imported box of chocolates at 11.25",
                    "1 Imported box of chocolates at 11.25"
                };
            }
        }


        //public static List<Product> Sample1()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(
        //        new Product(new NoTax(), new NoTax())
        //        {
        //            Name = "Book",
        //            Quantity = 2,
        //            ShelfPrice = 12.49M
        //        });

        //    products.Add(
        //        new Product(Tax.CreateSaleTax(), new NoTax())
        //        {
        //            Name = "Music CD",
        //            Quantity = 1,
        //            ShelfPrice = 14.99M
        //        });

        //    products.Add(
        //        new Product(new NoTax(), new NoTax())
        //        {
        //            Name = "Chocolate bar",
        //            Quantity = 1,
        //            ShelfPrice = 0.85M
        //        });

        //    return products;
        //}

        //public static List<Product> Sample2()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(
        //        new Product(new NoTax(), Tax.CreateImportTax())
        //        {
        //            Name = "Imported box of chocolates",
        //            Quantity = 1,
        //            ShelfPrice = 10.00M
        //        });

        //    products.Add(
        //        new Product(Tax.CreateSaleTax(), Tax.CreateImportTax())
        //        {
        //            Name = "Imported bottle of perfume",
        //            Quantity = 1,
        //            ShelfPrice = 47.50M
        //        });

        //    return products;
        //}

        //public static List<Product> Sample3()
        //{
        //    List<Product> products = new List<Product>();
        //    products.Add(
        //        new Product(Tax.CreateSaleTax(), Tax.CreateImportTax())
        //        {
        //            Name = "Imported bottle of perfume",
        //            Quantity = 1,
        //            ShelfPrice = 27.99M
        //        });

        //    products.Add(
        //        new Product(Tax.CreateSaleTax(), new NoTax())
        //        {
        //            Name = "Bottle of perfume",
        //            Quantity = 1,
        //            ShelfPrice = 18.99M
        //        });

        //    products.Add(
        //        new Product(new NoTax(), new NoTax())
        //        {
        //            Name = "Packet of headache pills",
        //            Quantity = 1,
        //            ShelfPrice = 9.75M
        //        });

        //    products.Add(
        //        new Product(new NoTax(), Tax.CreateImportTax())
        //        {
        //            Name = "Imported box of chocolates",
        //            Quantity = 2,
        //            ShelfPrice = 11.25M
        //        });

        //    return products;
        //}
    }
}
