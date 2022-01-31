using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ExpenseCategoryService
    {
        public bool CreateExpenseCategory(string userName, string categoryName)
        {
            using (var context = new EconomiqContext())
            {
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("No User with this Username.");
                }
                var category = context.ExpensesCategory.Where(c=>c.CategoryName.ToLower() == categoryName.ToLower()).FirstOrDefault();
                if (category == null)
                {
                    var expenseCategory = new ExpenseCategory { CategoryName = categoryName, CreationDate = DateTime.Now };
                    //context.ExpensesCategory.Add(expenseCategory);
                    
                    if(user.ExpensesCategoryNav == null)
                    {
                        var expenseCategoryList = new List<ExpenseCategory> { expenseCategory };
                        user.ExpensesCategoryNav = expenseCategoryList;
                    }
                    else
                    {
                        user.ExpensesCategoryNav.Add(expenseCategory);
                        
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
                else
                {
                    if(user.ExpensesCategoryNav == null)
                    {
                        var expenseCategoryList = new List<ExpenseCategory> { category };
                        user.ExpensesCategoryNav = expenseCategoryList;
                    }
                    else
                    {
                        user.ExpensesCategoryNav.Add(category);
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
        }
    }
}
