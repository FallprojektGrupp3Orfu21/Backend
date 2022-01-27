using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //Is this really needed if using jwt authentication? 
        public string Fname { get; set; }
        public string Lname { get; set; } 
        
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        //Navigational Properties
        //For Expense
        public List<Expense>? UserExpensesNav { get; set; }
        //For ExpenseCategory
        public List<ExpenseCategory>? ExpensesCategoryNav { get; set;}
        //Email
        public List<Email> Emails { get; set; }
    }
}
