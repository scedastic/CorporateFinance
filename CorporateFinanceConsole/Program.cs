using CorporateFinance;

namespace CorporateFinanceConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while (!input.ToUpper().Equals("X"))
            {
                Console.WriteLine("Choose from the following:\n");
                Console.WriteLine("1) Mortgage Payment Calculator and Amortization Table.");
                Console.WriteLine("\nX) Exit.");
                input = Console.ReadLine();

                switch(input.ToUpper())
                {
                    case "1":
                        MortgageCalculator();
                        break;
                    case "X":
                        Console.WriteLine("Exiting.");
                        break;
                    default:
                        Console.WriteLine("\nInvalid Choice.\n");
                        break;
                }
            }
        }

        private static void MortgageCalculator()
        {
            Console.WriteLine("What is the Loan Amount?");
            var principal = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the annual interest rate (APR)%?");
            var apr = float.Parse(Console.ReadLine()) / 100;
            Console.WriteLine("For how many years?");
            var years = int.Parse(Console.ReadLine());

            var mortgage = new AmortizationSchedule(principal, apr, years);
            Console.WriteLine($"Your monthly payment will be: $ {mortgage.MonthlyPayment:.2f}");
        }
    }
}
