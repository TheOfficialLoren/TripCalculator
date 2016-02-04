using System.Collections.Generic;

namespace TripCalculator.Models
{
    public class CalculationResponse
    {
        public CalculationResponse()
        {
            PaymentsDue = new List<Payment>();
        }
        public List<Payment> PaymentsDue { get; set; }
    }
}