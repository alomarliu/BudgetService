using System.Collections.Generic;

namespace BudgetService
{
    public class DBRepo :IBudgetRepo
    {
        private List<Budget> _datas = new List<Budget>()
        {
            new Budget(yearMonth: "202201", amount: 310),
            new Budget(yearMonth: "202202", amount: 28),
            new Budget(yearMonth: "202203", amount: 3100),
            new Budget(yearMonth: "202205", amount: 31),
            new Budget(yearMonth: "202206", amount: 300),
            new Budget(yearMonth: "202207", amount: 310),
            new Budget(yearMonth: "202208", amount: 0),
            new Budget(yearMonth: "202209", amount: 300),
        };

        public List<Budget> GetAll()
        {

            return _datas;
        }
    }
}