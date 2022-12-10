using System;

namespace BudgetService
{
    public class Budget
    {
        public string yearMonth;
        public int amount;
        public int year;
        public int month;

        public Budget(string yearMonth, int amount)
        {
            this.yearMonth = yearMonth;
            this.amount = amount;

            var dateTime = DateTime.ParseExact(yearMonth, "yyyyMM", null);

            year = dateTime.Year;
            month = dateTime.Month;
        }
    }
}