using SalesTax.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Contracts.BL
{
    public interface IProductAdapter
    {
        Product Process(string line);
    }
}
