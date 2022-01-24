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
        public int id { get; set; }
        [DataType(DataType.Currency)]
        public float Amount { get; set; }

        public Recipient Recipient {get; set;}

        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }

        public ExpenseCategory ExpenseCategory { get; set; }
        public string? Comment { get; set; }
    }
}
