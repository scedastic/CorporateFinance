using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinance
{
    public class NetPresentValue
    {
        private List<CashFlow> _cashFlows;
        public double InitialInvestment
        {
            get
            {
                if(_cashFlows.Count > 0)
                    return _cashFlows[0].Amount;
                else return 0;
            }
        }

        public NetPresentValue() 
        {
            _cashFlows = new List<CashFlow>();
        }

        public NetPresentValue(double initialAmount): this()
        {
            
            _cashFlows.Add(
                new CashFlow{ 
                    Amount = initialAmount, 
                    Rate = 0.0, 
                    SequenceNumber = 0 }
                );
        }

        public double NPV
        {
            get
            {
                var npv = 0.0;
                foreach (var c in _cashFlows)
                {
                    npv += c.DiscountedAmount; 
                }
                return npv;
            }
        }

        public void AddCashFlow(CashFlow c)
        {
            _cashFlows.Add(c);
        }

        /// <summary>
        /// Add amount using the rate from the previous cash flow to the end of the cash flow series.
        /// </summary>
        /// <param name="amount"></param>
        public void AddCashFlow(double amount)
        {
            var lastIndex = _cashFlows.Count - 1;
            AddCashFlow(amount, _cashFlows[lastIndex].Rate);
        }
        /// <summary>
        /// Add amount and rate to the end of the cash flow series.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="rate"></param>
        public void AddCashFlow(double amount, double rate)
        {
            _cashFlows.Add(new CashFlow { 
                Amount = amount, 
                Rate = rate, 
                SequenceNumber = _cashFlows.Count });
        }
    }
}
