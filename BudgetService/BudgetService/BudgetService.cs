using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BudgetService
{
    public class BudgetService
    {
        private readonly IBudgetRepo _repo;

        private List<Budget> budgets = new List<Budget>();

        public BudgetService(IBudgetRepo repo)
        {
            _repo = repo;
        }

        public decimal Query(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime)
                return 0;

            var startYD = new DateTime(startTime.Year, startTime.Month, 1);
            var currentYd = startYD;
            var endYd = new DateTime(endTime.Year, endTime.Month, 1);
            decimal totalAmount = 0;

            budgets = _repo.GetAll();

            while (currentYd <= endYd)
            {
                var daysInMonth = DateTime.DaysInMonth(currentYd.Year, currentYd.Month);

                if (currentYd == startYD)
                {
                    var days = daysInMonth - startTime.Day + 1;
                    totalAmount += GetPartMonthTotal(startYD.Year, startYD.Month, days);
                }
                else if (currentYd == endYd)
                {
                    totalAmount += GetPartMonthTotal(endYd.Year, endYd.Month, endTime.Day);
                }
                else
                {
                    totalAmount += GetMonthTotal(currentYd.Year, currentYd.Month);

                }

                Console.WriteLine($"{currentYd}, {totalAmount}");
                currentYd = currentYd.AddMonths(1);
            }

            return totalAmount;
        }

        private decimal GetMonthTotal(int year, int month)
        {
            return budgets.Where(x => x.year == year && x.month == month)
                            .Select(s => s.amount).First();
        }

        private decimal GetPartMonthTotal(int year , int month , int days)
        {
            var daysInMonth = DateTime.DaysInMonth(year, month);

            return  (days == daysInMonth)? GetMonthTotal(year, month) : 
                                        GetMonthTotal(year, month) / (decimal)daysInMonth * days;
        }
    }
}