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

        public static bool LoanToValue(decimal loanAmount, decimal assetValue, int creditScore)
        {
            decimal ltv = (loanAmount / assetValue) * 100;

            if (loanAmount > 1500000m || loanAmount < 100000m)
            {
                return false;
            }
            else if (loanAmount >= 1000000m)
            {
                return (ltv <= 60m && creditScore >= 950);
            }
            else
            {
                if (ltv < 60m && creditScore >= 750)
                {
                    return true;
                }
                else if (ltv < 80m && creditScore >= 800)
                {
                    return true;
                }
                else if (ltv < 90m && creditScore >= 900)
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
}
