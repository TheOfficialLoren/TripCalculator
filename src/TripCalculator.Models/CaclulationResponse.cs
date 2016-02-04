using System.Collections.Generic;

namespace TripCalculator.Models
{
    public class CalculationResponse
    {
        public List<Payment> PaymentsDue { get; set; }
    }

    public class Payment
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal Amount { get; set; }
    }
}