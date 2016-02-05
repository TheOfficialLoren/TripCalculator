using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripCalculator.Models;
using TripCalculator.Services;

namespace TripCalculator.Tests
{
    [TestClass]
    public class CalculationServicesTests
    {
        /// <summary>
        /// A basic test between 2 students
        /// </summary>
        [TestMethod]
        public void TestMethod01()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 40m},
                            new Expense() { Name = "Store", Amount = 50m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 10m},
                            new Expense() { Name = "Beer", Amount = 150m},
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(1, response.PaymentsDue.Count);
            Assert.AreEqual(35m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Jack", response.PaymentsDue[0].From);
            Assert.AreEqual("Charlie", response.PaymentsDue[0].To);
        }
        
        /// <summary>
        /// A basic test between 3 students
        /// </summary>
        [TestMethod]
        public void TestMethod02()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 40m},
                            new Expense() { Name = "Store", Amount = 50m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 10m},
                            new Expense() { Name = "Beer", Amount = 150m},
                        }
                    },
                    new Student {
                        Name = "Loren", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "More beer", Amount = 60m},
                            new Expense() { Name = "Limes", Amount = 2m},
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(2, response.PaymentsDue.Count);

            Assert.AreEqual(42m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[0].From);
            Assert.AreEqual("Charlie", response.PaymentsDue[0].To);

            Assert.AreEqual(14m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Jack", response.PaymentsDue[1].From);
            Assert.AreEqual("Charlie", response.PaymentsDue[1].To);
        }
        
        /// <summary>
        /// A basic test between 4 students
        /// </summary>
        [TestMethod]
        public void TestMethod03()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 40m},
                            new Expense() { Name = "Store", Amount = 10m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 10m},
                            new Expense() { Name = "Beer", Amount = 50m},
                        }
                    },
                    new Student {
                        Name = "Loren", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "More beer", Amount = 80m},
                            new Expense() { Name = "Limes", Amount = 40m},
                        }
                    },
                    new Student {
                        Name = "Zach", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Aspirin", Amount = 5m},
                            new Expense() { Name = "Gatorade", Amount = 5m},
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(2, response.PaymentsDue.Count);

            Assert.AreEqual(50m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Zach", response.PaymentsDue[0].From);
            Assert.AreEqual("Loren", response.PaymentsDue[0].To);

            Assert.AreEqual(10m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Jack", response.PaymentsDue[1].From);
            Assert.AreEqual("Loren", response.PaymentsDue[1].To);
        }

        /// <summary>
        /// A basic test between 4 students
        /// </summary>
        [TestMethod]
        public void TestMethod04()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 5m},
                            new Expense() { Name = "Store", Amount = 5m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 2m},
                            new Expense() { Name = "Beer", Amount = 11m},
                        }
                    },
                    new Student {
                        Name = "Loren", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Vitamins", Amount = 3m},
                            new Expense() { Name = "Limes", Amount = 1m},
                        }
                    },
                    new Student {
                        Name = "Zach", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Aspirin", Amount = 3m},
                            new Expense() { Name = "Gatorade", Amount = 3m},
                            new Expense() { Name = "Beef Jerkey", Amount = 3m},
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(2, response.PaymentsDue.Count);

            Assert.AreEqual(4m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[0].From);
            Assert.AreEqual("Charlie", response.PaymentsDue[0].To);

            Assert.AreEqual(1m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[1].From);
            Assert.AreEqual("Jack", response.PaymentsDue[1].To);
        }

        /// <summary>
        /// A test where 3 students all paid the same amount by chance
        /// </summary>
        [TestMethod]
        public void TestMethod05()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student
                    {
                        Name = "Jack",
                        Expenses = new List<Expense>
                        {
                            new Expense() {Name = "Gas", Amount = 5m},
                            new Expense() {Name = "Store", Amount = 5m},
                        }
                    },
                    new Student
                    {
                        Name = "Charlie",
                        Expenses = new List<Expense>
                        {
                            new Expense() {Name = "Sun screen", Amount = 7m},
                            new Expense() {Name = "Beer", Amount = 3m},
                        }
                    },
                    new Student
                    {
                        Name = "Loren",
                        Expenses = new List<Expense>
                        {
                            new Expense() {Name = "More beer", Amount = 3m},
                            new Expense() {Name = "Limes", Amount = 4m},
                            new Expense() {Name = "More Lime", Amount = 3m},
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(0, response.PaymentsDue.Count);
        }

        /// <summary>
        /// A test where there are no students
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestMethod06()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(0, response.PaymentsDue.Count);
        }

        /// <summary>
        /// A test with 5 students for good measure
        /// </summary>
        [TestMethod]
        public void TestMethod07()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 1m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 1m},
                        }
                    },
                    new Student {
                        Name = "Loren", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Vitamins", Amount = 3m},
                        }
                    },
                    new Student {
                        Name = "Zach", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Aspirin", Amount = 3m},
                            new Expense() { Name = "Gatorade", Amount = 3m},
                            new Expense() { Name = "Beef Jerkey", Amount = 4m},
                        }
                    },
                    new Student {
                        Name = "Ian", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Chips. Lots of chips", Amount = 10m}
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(4, response.PaymentsDue.Count);

            Assert.AreEqual(4m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Jack", response.PaymentsDue[0].From);
            Assert.AreEqual("Ian", response.PaymentsDue[0].To);

            Assert.AreEqual(4m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Charlie", response.PaymentsDue[1].From);
            Assert.AreEqual("Zach", response.PaymentsDue[1].To);

            Assert.AreEqual(1m, response.PaymentsDue[2].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[2].From);
            Assert.AreEqual("Zach", response.PaymentsDue[2].To);

            Assert.AreEqual(1m, response.PaymentsDue[3].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[3].From);
            Assert.AreEqual("Ian", response.PaymentsDue[3].To);
        }
        
        /// <summary>
        /// A unit test with 3 where rounding comes into account.
        /// </summary>
        [TestMethod]
        public void TestMethod08()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 3m}
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 2m}
                        }
                    },
                    new Student {
                        Name = "Loren", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "More beer", Amount = 5m}
                        }
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(2, response.PaymentsDue.Count);

            Assert.AreEqual(1.33m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Charlie", response.PaymentsDue[0].From);
            Assert.AreEqual("Loren", response.PaymentsDue[0].To);

            Assert.AreEqual(.33m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Jack", response.PaymentsDue[1].From);
            Assert.AreEqual("Loren", response.PaymentsDue[1].To);
        }

        /// <summary>
        /// A basic test between 3 students. 1 student has 0 payments.
        /// </summary>
        [TestMethod]
        public void TestMethod09()
        {
            CalculationRequest request = new CalculationRequest()
            {
                Students = new List<Student>()
                {
                    new Student {
                        Name = "Jack", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Gas", Amount = 40m},
                            new Expense() { Name = "Store", Amount = 50m},
                        }
                    },
                    new Student {
                        Name = "Charlie", Expenses = new List<Expense>
                        {
                            new Expense() { Name = "Sun screen", Amount = 10m},
                            new Expense() { Name = "Beer", Amount = 150m},
                        }
                    },
                    new Student {
                        Name = "Loren"
                    },
                }
            };

            CalculationResponse response = CalculationService.CalculateExpenses(request);

            Assert.AreEqual(2, response.PaymentsDue.Count);

            Assert.AreEqual(76.67m, response.PaymentsDue[0].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[0].From);
            Assert.AreEqual("Charlie", response.PaymentsDue[0].To);

            Assert.AreEqual(6.66m, response.PaymentsDue[1].Amount);
            Assert.AreEqual("Loren", response.PaymentsDue[1].From);
            Assert.AreEqual("Jack", response.PaymentsDue[1].To);
        }

    }
}
