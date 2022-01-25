using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpenseService
    {
        public ExpenseDTO AddExpense(ExpenseDTO expense)
        {
            //Add to db
            return expense;
        }
        public List<ExpenseDTO> GetExpensesByUser(UserDTO user)
        {
            var Expenses = new List<ExpenseDTO>();
            Expenses.Add(
                new ExpenseDTO
                {

                });
            return Expenses;
        }
    }
}
