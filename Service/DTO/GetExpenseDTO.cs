using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class GetExpenseDTO
    {
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string? Title { get; set; }
    }
}
