using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripCalculator.Models;

namespace TripCalculator.Services
{
    public class CalculationService
    {

        public static CalculationResponse CalculateExpenses(CalculationRequest request)
        {
            CalculationResponse response = new CalculationResponse();

            if (request == null || request.Students == null || !request.Students.Any())
            {
                throw new ArgumentException("No students in request");
            }
            decimal costPerStudent = decimal.Round(request.Students.Sum(st => st.TotalPaid) / request.Students.Count, 2);

            //todo: come up with a more elegant way to check if all students are all paid up or within $.01.
            //todo: This same statement is used down in the "while" clause. Centralize it.
            if (request.Students.All(student => student.TotalPaid >= (costPerStudent - .01m) && student.TotalPaid <= (costPerStudent + .01m)))
            {
                //all students are paid already, no need to continue here.
                return response;
            }

            do
            {
                Student smallestContributer = request.Students.OrderBy(st => st.TotalPaid).First();
                Student biggestContributer = request.Students.OrderByDescending(st => st.TotalPaid).First();
                decimal contributionAmt = Math.Min(biggestContributer.TotalPaid - costPerStudent,
                    costPerStudent - smallestContributer.TotalPaid);

                smallestContributer.Expenses.Add(new Expense { Amount = contributionAmt, Name = string.Format("Payment to {0}", biggestContributer.Name)});
                biggestContributer.Expenses.Add(new Expense { Amount = contributionAmt * -1, Name = string.Format("Payment from {0}", smallestContributer.Name)});
                response.PaymentsDue.Add(new Payment { Amount = contributionAmt, From = smallestContributer.Name, To = biggestContributer.Name});
            } while (!request.Students.All(student => student.TotalPaid >= (costPerStudent - .01m) && student.TotalPaid <= (costPerStudent + .01m)));

            return response;
        }
    }
}
