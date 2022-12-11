using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BudgetService
{
    [TestClass]
    public class BudgetServiceTest
    {
        [TestMethod]
        public void single_day_query()
        {
            var startTime = new DateTime(2022, 1, 31);
            var endTime = new DateTime(2022, 1, 31);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);
            
            Assert.AreEqual(10, budgetService.Query(startTime, endTime));
        }

        [TestMethod]
        public void single_month_query()
        {
            var startTime = new DateTime(2022, 1, 1);
            var endTime = new DateTime(2022, 1, 31);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);

            Assert.AreEqual(310, budgetService.Query(startTime, endTime));
        }

        [TestMethod]
        public void invalid_start_end_time_query()
        {
            var startTime = new DateTime(2023, 1, 31);
            var endTime = new DateTime(2022, 2, 2);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);
            Assert.AreEqual(0, budgetService.Query(startTime, endTime));
        }

        [TestMethod]
        public void two_month_query()
        {
            //new Budget() { yearMonth = "202201", amount = 310 },
            //new Budget() { yearMonth = "202202", amount = 28 },
            //new Budget() { yearMonth = "202203", amount = 3100 },
            //new Budget() { yearMonth = "202205", amount = 31 },
            //new Budget() { yearMonth = "202206", amount = 300 },
            //new Budget() { yearMonth = "202207", amount = 310 },
            //new Budget() { yearMonth = "202208", amount = 0 },
            //new Budget() { yearMonth = "202209", amount = 300 },
            var startTime = new DateTime(2022, 1, 31);
            var endTime = new DateTime(2022, 2, 2);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);

            Assert.AreEqual(12, budgetService.Query(startTime, endTime));
        }

        [TestMethod]
        public void three_month_query()
        {
            //new Budget() { yearMonth = "202201", amount = 310 },
            //new Budget() { yearMonth = "202202", amount = 28 },
            //new Budget() { yearMonth = "202203", amount = 3100 },
            //new Budget() { yearMonth = "202205", amount = 31 },
            //new Budget() { yearMonth = "202206", amount = 300 },
            //new Budget() { yearMonth = "202207", amount = 310 },
            //new Budget() { yearMonth = "202208", amount = 0 },
            //new Budget() { yearMonth = "202209", amount = 300 },
            var startTime = new DateTime(2022, 1, 31);
            var endTime = new DateTime(2022, 3, 1);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);

            Assert.AreEqual(138, budgetService.Query(startTime, endTime));
        }


        [TestMethod]
        public void none_data_query()
        {
            //new Budget() { yearMonth = "202201", amount = 310 },
            //new Budget() { yearMonth = "202202", amount = 28 },
            //new Budget() { yearMonth = "202203", amount = 3100 },
            //new Budget() { yearMonth = "202205", amount = 31 },
            //new Budget() { yearMonth = "202206", amount = 300 },
            //new Budget() { yearMonth = "202207", amount = 310 },
            //new Budget() { yearMonth = "202208", amount = 0 },
            //new Budget() { yearMonth = "202209", amount = 300 },
            var startTime = new DateTime(2022, 2, 28);
            var endTime = new DateTime(2022, 4, 1);

            var dbRepo = new DBRepo();
            var budgetService = new BudgetService(dbRepo);

            Assert.AreEqual(3101, budgetService.Query(startTime, endTime));
        }
    }
}
