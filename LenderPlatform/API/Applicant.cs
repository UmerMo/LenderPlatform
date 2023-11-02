using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenderPlatform.API
{
    public class Applicant
    {
        public int ID { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal AssetValue { get; set; }
        public int CreditScore { get; set; }
        public string LoanStatus { get; set; }
    }

}
