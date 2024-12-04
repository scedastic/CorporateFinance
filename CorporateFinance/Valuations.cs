using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinance
{
    public class Valuations
    {
        private static double CompoundInterest(double principal, double rate, int numberOfPeriods)
        {

            return principal * Math.Pow(1 + rate, numberOfPeriods);
        }

        public static double FutureValue(double presentValue, double rate, int numberOfPeriods)
        {
            if (numberOfPeriods <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfPeriods must be positive.", "numberOfPeriods");
            }
            return Valuations.CompoundInterest(presentValue, rate, numberOfPeriods);
        }
        public static double PresentValue(double futureValue, double rate, int numberOfPeriods)
        {
            if (numberOfPeriods <= 0)
            {
                throw new ArgumentOutOfRangeException("numberOfPeriods must be positive.", "numberOfPeriods");
            }
            return Valuations.CompoundInterest(futureValue, rate, -1 * numberOfPeriods);
        }

        public static double PerpetuityPresentValue(double cashFlow, double rate)
        {
            if (rate <= 0)
            {
                return 0;
            }
            return cashFlow / rate;
        }

        public static double GrowingPerpetuityPresentValue(double cashFlow, double rate, double cashFlowGrowthRate)
        {
            return PerpetuityPresentValue(cashFlow, rate - cashFlowGrowthRate);
        }

        public static double AnnuityPresentValue(double cashFlow, double rate, int periods)
        {
            return PerpetuityPresentValue(cashFlow, rate) * 1 - Math.Pow(1 + rate, periods);
        }

        /// <summary>
        /// Takes the Annual Percentage Rate and breaks it down per month for compounding and returns the monthly payment.
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="apr">Annual Percentage Rate</param>
        /// <param name="years"></param>
        /// <returns></returns>
        public static double GetMortgagePayment(double principal, double apr, int years)
        {
            double periodicRate = apr / 12;
            double compound = Math.Pow(1 +  periodicRate, years*12);
            return principal * periodicRate * compound / (compound - 1);
        }
    }
}
