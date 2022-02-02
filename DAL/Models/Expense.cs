using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public Recipient? Recipient {get; set;}

        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
        public DateTime CreationDate { get; set; }
       

        
        public string? Comment { get; set; }
        //Navigational Properites
        //For User Relation
        public int UserNavId { get; set; }
        public User? UserNav { get; set; }
        //For Category
        public int? CategoryNavId;
        public ExpenseCategory? CategoryNav { get; set; }
    }
}
