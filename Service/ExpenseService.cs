using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Service.Models;
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
        private UserService _userService;
        public ExpenseService()
        {
            _expenseCategoryService = new ExpenseCategoryService();
            _userService = new UserService();

        }
        public bool AddExpense(ExpenseDTO expense, string userName)
        {
            using (var context = new EconomiqContext())
            {
                //Gest the user by username
                var user = context.Users.Where(user => user.UserName == userName).Include(r => r.RecipientNav).FirstOrDefault();
                var recipient = user.RecipientNav.Where(rec => rec.Name == expense.RecipientName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No User with this Username.");
                }
                //Gets the category the expense belongs to, or creates one if it doesnt exist.
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
                        throw new Exception("Could not create missing Category");
                    }
                }
                //Length Check for title/comment
                if (expense.Title.Length > 50)
                {
                    throw new Exception("Title Too Long (Needs to be less than 50 characters)");
                }
                //Creates the expense and adds it to the user (creates list ifs the first expense on the user)
                DateTime expenseDate = DateTime.Parse(expense.ExpenseDate).Date;
                DateTime creationDate = DateTime.Now;
                var newExpense = new Expense { Amount = expense.Amount, CreationDate = creationDate, ExpenseDate = expenseDate, Comment = expense.Title, UserNavId = user.Id, CategoryNavId = category.Id, RecipientNavId = recipient.Id };

                if (user.UserExpensesNav == null)
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

        public List<GetExpenseDTO> GetAllExpensesByUsername(string Username)
        {
            List<GetExpenseDTO> listToReturn = new List<GetExpenseDTO>();

            using (var context = new EconomiqContext())
            {



                var user = context.Users.Include(e => e.UserExpensesNav).ThenInclude(e=>e.CategoryNav).Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == Username);
                var expenses = user.UserExpensesNav.ToList();


                foreach (var expense in expenses)
                {
                    listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name }) ;

                }
                return listToReturn;


            }
        }
        public List<GetExpenseDTO> GetFilteredList(FilterExpenseDTO filterDTO, string username)
        {
            List<GetExpenseDTO> listToReturn = new List<GetExpenseDTO>();

            using (var context = new EconomiqContext())
            {
                var user = context.Users.Include(e => e.UserExpensesNav).ThenInclude(e => e.CategoryNav).Include(e => e.RecipientNav).FirstOrDefault(x => x.UserName == username);
                var expenses = new List<Expense>();

                switch (filterDTO.FilteredBy)
                {
                    case "HighestPrice":
                        expenses = user.UserExpensesNav.OrderByDescending(e => e.Amount).ToList();
                        break;
                    case "LowestPrice":
                        expenses = user.UserExpensesNav.OrderBy(e => e.Amount).ToList();
                        break;
                    case "Newest":
                        expenses = user.UserExpensesNav.OrderByDescending(e => e.ExpenseDate).ToList();
                        break;
                    case "Oldest":
                        expenses = user.UserExpensesNav.OrderBy(e => e.ExpenseDate).ToList();
                        break;
                    case "RecieverName":
                        expenses = user.UserExpensesNav.OrderBy(e => e.RecipientNav.Name).ToList();
                        break;
                    default:
                        expenses = user.UserExpensesNav.ToList();
                        break;
                }
                foreach (var expense in expenses)
                {
                    listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate.ToString("dd/MM/yyyy"), categoryName = expense.CategoryNav.CategoryName, RecipientName = expense.RecipientNav.Name });

                }
                return listToReturn;
            }
        }

        
        

    }
}
