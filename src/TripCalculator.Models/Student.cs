using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TripCalculator.Models
{
    public class Student
    {
        public Student()
        {
            Expenses = new List<Expense>();
        }
        public string Name { get; set; }
        public List<Expense> Expenses { get; set; }

        public Decimal TotalPaid
        {
            get
            {
                return Expenses.Sum(e => e.Amount);
            }
        }
    }
}
