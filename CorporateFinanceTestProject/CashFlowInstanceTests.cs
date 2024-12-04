using CorporateFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinanceTestProject
{
    public class CashFlowInstanceTests
    {
        /// <summary>
        /// These numbers were taken from the PV table - with PV and FV multiplied by 100.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="rate"></param>
        /// <param name="sequenceNumber"></param>
        /// <param name="discountedAmount"></param>
        [TestCase(100, 0.04, 1, 96.2)]
        [TestCase(100, 0.04, 5, 82.2)]
        [TestCase(100, 0.13, 1, 88.5)]
        [TestCase(100, 0.16, 11, 19.5)]
        public void TestDiscounting(double amount, double rate, int sequenceNumber, double discountedAmount)
        {
            var subject = new CashFlow();
            subject.Amount = amount;
            subject.SequenceNumber = sequenceNumber;
            subject.Rate = rate;
            Assert.That(subject.DiscountedAmount, Is.EqualTo(discountedAmount).Within(0.1));
        }
    }
}
