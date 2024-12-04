using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinance
{
    public class AmortizationSchedule
    {
        private double _principal;
        private double _apr;
        private int _years;
        private double _monthlyPayment;
        public double Principal 
        { 
            get { return _principal; } 
            set
            {
                _principal = value;
                ResetSchedule();
            }
        }

        public double APR 
        {  
            get { return _apr; }
            set
            {
                _apr = value;
                ResetSchedule();
            }
        }

        public int Years
        {
            get { return _years; }
            set
            {
                _years = value;
                ResetSchedule();
            }
        }

        public double MonthlyPayment { get { return _monthlyPayment; } }

        public List<AmortizationRecord> AmortizationTable { get; set; }
        public AmortizationSchedule(double principal, double apr, int years) 
        { 
            _principal = principal;
            _apr = apr;
            _years = years;
            _monthlyPayment = Valuations.GetMortgagePayment(principal, apr, years);
            ResetSchedule();
        }
        private void ResetSchedule()
        {
            double principalLeft = _principal;
            AmortizationTable = new List<AmortizationRecord>();
            for(int i = 0; i < _years * 12; i++)
            {
                var amortization = new AmortizationRecord();
                amortization.SequenceID = i + 1;
                amortization.Payment = _monthlyPayment;
                amortization.Principal = principalLeft;
                amortization.Interest = principalLeft * _apr / 12;
                AmortizationTable.Add(amortization);
                principalLeft = amortization.Principal + amortization.Interest - MonthlyPayment;
            }
        }
    }
}
