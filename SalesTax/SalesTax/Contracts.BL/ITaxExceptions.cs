using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax.Contracts.BL
{
    public interface ITaxExceptions
    {
        bool IsTaxApply(string value);
    }
}
