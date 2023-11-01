using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenderPlatform
{
    public class LoanCalculator
    {
        public static bool IsLoanAmountInRange(decimal loanAmount)
        {
            if (loanAmount >= 100000m && loanAmount <= 1500000m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
