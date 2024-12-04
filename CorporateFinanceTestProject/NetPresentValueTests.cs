using CorporateFinance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinanceTestProject
{
    public class NetPresentValueTests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Create a set of cash flows of 2200 for 6 years at 20% with initial investment of 6000.
        /// </summary>
        /// <returns>NPV object</returns>
        private NetPresentValue NpvSetOne()
        {
            var npv = new NetPresentValue(-6000);
            for (int i = 0; i < 6; i++)
                npv.AddCashFlow(2200, 0.2);
            return npv;

        }
        /// <summary>
        /// Create a set of cash flows of 4200 for 15 years at 25% with initial investment of 15000.
        /// </summary>
        /// <returns>NPV object</returns>
        private NetPresentValue NpvSetTwo()
        {
            var npv = new NetPresentValue(-15000);
            for (int i = 0; i < 15; i++)
                npv.AddCashFlow(4200, 0.25);
            return npv;

        }

        [Test]
        public void TestInitialFlowOnly()
        {
            var subject = new NetPresentValue(-100);
            Assert.That(subject.NPV, Is.EqualTo(-100));
        }

        [Test]
        public void TestSetOne()
        {
            var subject = NpvSetOne();
            Assert.That(subject.NPV, Is.EqualTo(1317.0).Within(1.0));
        }
        [Test]
        public void TestSetTwo()
        {
            var subject = NpvSetTwo();
            Assert.That(subject.NPV, Is.EqualTo(1208.0).Within(1.0));
        }


        [Test]
        public void TestCapitalProject()
        {
            var subject = new NetPresentValue(-100_000);
            subject.AddCashFlow(new CashFlow { Amount = -200_000, Rate = 0.2, SequenceNumber = 1 });
            subject.AddCashFlow(-200_000);
            subject.AddCashFlow(1_000_000);
            Assert.That(subject.NPV, Is.EqualTo(173_148).Within(1.0));
        }
    }
}
