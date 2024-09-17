using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Application.Common.Interfaces;

public interface ITaxRule
{
    int GetTollFee(DateTime dateTime);
    bool IsTollFreeDate(DateTime dateTime);
}
