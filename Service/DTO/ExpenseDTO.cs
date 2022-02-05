using DAL.Models;

namespace Service
{

    public class GetExpenseDTO
    {
        public string Title { get; set; }
        public string ExpenseDate { get; set; } // Currently needs format "Jan 1, 2009" or "2022-01-28" - Might not be used depending on Johannas opinion on Expense date (customizable to day expense happened or using date expense created in program.
        public decimal Amount { get; set; }
        public string CategoryName { get; set; }
        public int ErrorCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}