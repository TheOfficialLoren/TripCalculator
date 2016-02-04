using System.Collections.Generic;

namespace TripCalculator.Models
{
    public class CalculationRequest
    {
        public List<Student> Students { get; set; }
    }

    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}