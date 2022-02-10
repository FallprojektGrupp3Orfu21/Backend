﻿using DAL.Models;
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
                var user = context.Users.Where(user => user.UserName == userName).FirstOrDefault();
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
                        throw new Exception("Something Went Wrong Here");
                    }
                }
                //Length Check for title/comment
                if (expense.Title.Length > 50)
                {
                    throw new Exception("Title Too Long (Needs to be less than 50 characters)");
                }
                //Creates the expense and adds it to the user (creates list ifs the first expense on the user)
                DateTime expenseDate = DateTime.Parse(expense.ExpenseDate);
                DateTime creationDate = DateTime.Now;
                var newExpense = new Expense { Amount = expense.Amount, CreationDate = creationDate, ExpenseDate = expenseDate, Comment = expense.Title, UserNavId = user.Id, CategoryNavId = category.Id };

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



                var user = context.Users.Include(e => e.UserExpensesNav).FirstOrDefault(x => x.UserName == Username);
                var expenses = user.UserExpensesNav.ToList();


                foreach (var expense in expenses)
                {
                    listToReturn.Add(new GetExpenseDTO { Amount = expense.Amount, Title = expense.Comment, ExpenseDate = expense.ExpenseDate });

                }
                return listToReturn;


            }
        }


    }
}
