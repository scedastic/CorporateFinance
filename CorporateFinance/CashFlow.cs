using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinance
{
    public class CashFlow
    {
        /// <summary>
        /// Cash Flow Amount. Positive for income, negative for payout.
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// Rate of discount. 1 will be added when necessary.
        /// </summary>
        public double Rate { get; set; }
        public int SequenceNumber { get; set; }

        public double DiscountedAmount
        {
            get
            {
                return Amount * Math.Pow(1+Rate, -1 * SequenceNumber);
            }
        }
    }
}
