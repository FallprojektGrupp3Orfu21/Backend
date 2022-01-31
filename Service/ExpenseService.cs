using DAL.Models;
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
        private ExpenseCategoryService _expenseCategoryService;
        public ExpenseService()
        {
            _expenseCategoryService = new ExpenseCategoryService();
        }
        public bool AddExpense(ExpenseDTO expense, string userName)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No User with this Username.");
                }
                var category = context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
                if (category == null)
                {
                    try
                    {
                        _expenseCategoryService.CreateExpenseCategory(userName, expense.CategoryName);
                        category = context.ExpensesCategory.Where(c => c.CategoryName.ToLower() == expense.CategoryName.ToLower()).FirstOrDefault();
                    }
                    catch 
                    {
                        throw new Exception("Something Went Wrong Here");
                    } 
                }
                if(expense.Title.Length > 50)
                {
                    throw new Exception("Title Too Long (Needs to be less than 50 characters)");
                }
                //DateTime creationDate = DateTime.Parse(expense.Date); -Read Comment on date in ExpenseDTO
                DateTime creationDate = DateTime.Now;
                var newExpense = new Expense { Amount = expense.Amount, ExpenseDate = creationDate, Comment = expense.Title, UserNavId = user.Id, CategoryNavId = category.Id};
                
                if(user.UserExpensesNav == null)
                {
                    user.UserExpensesNav = new List<Expense> { newExpense };
                }
                else
                {
                    user.UserExpensesNav.Add(newExpense);
                }
                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch
                {
                    throw new Exception("Something went wrong");
                }
            }
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
