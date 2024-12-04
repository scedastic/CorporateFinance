using CorporateFinance;

namespace CorporateFinanceTestProject;

public class ValuationsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(100, 0.1, 1, 110.0)]
    [TestCase(100, 0.2, 1, 120.0)]
    [TestCase(100, 0.1, 2, 121.0)]
    public void TestFutureValue(double present, double rate, int periods, double future)
    {
        Assert.That(Valuations.FutureValue(present, rate, periods), Is.EqualTo(future).Within(0.01));
    }

    [Test]
    public void TestFutureValueOnlyPositivePeriods()
    {
        Assert.That(() => Valuations.FutureValue(100, 0.1, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }


    [TestCase(110, 0.1, 1, 100.0)]
    [TestCase(121.0, 0.1, 2, 100.0)]
    public void TestPresentValue(double future, double rate, int periods, double present)
    {
        Assert.That(Valuations.PresentValue(future, rate, periods), Is.EqualTo(present).Within(0.01));
    }

    [Test]
    public void TestPresentValueOnlyPositivePeriods()
    {
        Assert.That(() => Valuations.PresentValue(100, 0.1, -1), Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(416_000, 0.04, 30, 1986.05)]
    public void TestGetMortgagePayment(double principal, double apr, int years, double payment)
    {
        Assert.That(Valuations.GetMortgagePayment(principal, apr, years), Is.EqualTo(payment).Within(0.01));
    }
}
