using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateFinance
{
    /// <summary>
    /// Represents a single row in an Amortization Table.
    /// </summary>
    public class AmortizationRecord
    {
        /// <summary>
        /// Which payment number does this record refer to.
        /// </summary>
        public int SequenceID { get; set; }
        /// <summary>
        /// The amount of Principal left at the beginning of this period.
        /// </summary>
        public double Principal {  get; set; }
        /// <summary>
        /// The amount of interest at the end of this period.
        /// </summary>
        public double Interest {  get; set; }
        /// <summary>
        /// The payment amount that is expected at the end of this period.
        /// </summary>
        public double Payment { get; set; }

        /// <summary>
        /// The portion of the payment that is applied to the remaining principal.
        /// </summary>
        public double PaymentAppliedToPrincipal
        {
            get
            {
                return Payment - Interest;
            }
        }

    }
}
