namespace Service.DTO
{
    public class GetExpenseDTO
    {
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string categoryName { get; set; }
        public string? Title { get; set; }
    }
}
