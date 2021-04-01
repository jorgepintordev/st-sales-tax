using SalesTax.BL;
using SalesTax.BL.Builders;
using SalesTax.BL.Taxes;
using System;
using System.Collections.Generic;

namespace SalesTax
{
    class Program
    {
        static void Main(string[] args)
        {
            //Allow custom input values or show with sample data
            if (args.Length > 0)
            {
                StartProcess(args);
            }
            else
            {
                PrintSamples();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Process starter of ShoppingCart to PrintReceipt 
        /// </summary>
        /// <param name="input">Products raw array</param>
        /// <param name="index">Helper for title on SampleData. Default value 0</param>
        static void StartProcess(string[] input, int index = 0)
        {
            try
            {
                //create ShoppingCart object with ShoppingCartBuilder
                var shoppingCart = new ShoppingCartBuilder(new ProductAdapter(Tax.CreateSaleTax(), Tax.CreateImportTax(), new TaxExceptions()))
                        .CreateShoppingCart(input);
                var result = shoppingCart.PrintReceipt();

                PrintResult(input, result, index);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Print input array and rpcessed data result
        /// </summary>
        /// <param name="input">Prodcts raw array to print</param>
        /// <param name="result">Poocessed data to print</param>
        /// <param name="index">Helper for title on SampleData</param>
        static void PrintResult(string[] input, string result, int index)
        {
            string subtilte = index > 0 ? $" {index}" : "";
            Console.WriteLine($"--- Input{subtilte} ---");
            PrintInput(input);
            Console.WriteLine();

            Console.WriteLine($"--- Output{subtilte} ---");
            Console.WriteLine(result);

            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// Print input array
        /// </summary>
        /// <param name="input">Prodcts raw array to print</param>
        static void PrintInput(string[] input)
        {
            foreach (var line in input)
            {
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// SampleData process initializer
        /// </summary>
        static void PrintSamples()
        {
            List<string[]> samples = new List<string[]>() { SampleData.Input1, SampleData.Input2, SampleData.Input3 };

            for (int x = 0; x < samples.Count; x++)
            {
                StartProcess(samples[x], x + 1);
            }
        }
    }
}
