using System;
using System.Collections.Generic;
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
        public Email Email { get; set; }
        public Expense Expense { get; set; }
    }
}
