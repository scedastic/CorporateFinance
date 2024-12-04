using CorporateFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinanceTestProject
{
    public class AmortizationScheduleTests
    {
        [Test]
        public void ThirtyYear400K4PctTest()
        {
            AmortizationSchedule schedule = new AmortizationSchedule(400_000, 0.04, 30);
            Assert.That(schedule.MonthlyPayment, Is.EqualTo(1909.66).Within(0.01));
            Assert.That(schedule.AmortizationTable[0].Interest, Is.EqualTo(1333.33).Within(0.01));
            Assert.That(schedule.AmortizationTable[359].Principal, Is.LessThanOrEqualTo(schedule.MonthlyPayment));
        }
    }
}
