using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var u1 = new User() { Id = 1, UserName = "JuliaH", Fname = "Julia", Lname = "Hook", Password = "Testing123", CreationDate = DateTime.Now };
            var u2 = new User() { Id = 2, UserName = "AlexV", Fname = "Alexander", Lname = "Volonen", Password = "Testing234", CreationDate = DateTime.Now };
            var u3 = new User() { Id = 3, UserName = "Peppo", Fname = "Stefan", Lname = "Krakowsky", Password = "Testing345", CreationDate = DateTime.Now };
            var u4 = new User() { Id = 4, UserName = "WinnieH", Fname = "Winnie", Lname = "Huynh", Password = "Testing456", CreationDate = DateTime.Now };
            var u5 = new User() { Id = 5, UserName = "Ericx", Fname = "Eric", Lname = "Flodin", Password = "Testing567", CreationDate = DateTime.Now };
            var u6 = new User() { Id = 6, UserName = "AndersB", Fname = "Anders", Lname = "Bergstrom", Password = "Testing678", CreationDate = DateTime.Now };
            var u7 = new User() { Id = 7, UserName = "PeterH", Fname = "Peter", Lname = "Hafid", Password = "Testing789", CreationDate = DateTime.Now };
            modelBuilder.Entity<User>().HasData(u1, u2, u3, u4, u5, u6, u7);

            var em1 = new Email() { Mail = "JuliaH@test.com" , UserNavId = 1};
            var em2 = new Email() { Mail = "AlexV@test.com" , UserNavId = 2};
            var em3 = new Email() { Mail = "Peppo@test.com" , UserNavId = 3};
            var em4 = new Email() { Mail = "WinnieH@test.com" , UserNavId = 4};
            var em5 = new Email() { Mail = "Ericx@test.com" , UserNavId = 5};
            var em6 = new Email() { Mail = "AndersB@test.com" , UserNavId = 6};
            var em7 = new Email() { Mail = "PeterH@test.com" , UserNavId = 7};
            modelBuilder.Entity<Email>().HasData(em1, em2, em3, em4, em5, em6, em7);

            var ec = new ExpenseCategory() { Id = 1, CategoryName = "Snacks", UserNavId = 1, CreationDate = DateTime.Now };
            modelBuilder.Entity<ExpenseCategory>().HasData(ec);

            var e1 = new Expense() { Id = 1, Amount = 25, Comment = "Glass", CategoryNavId = 1, ExpenseDate = DateTime.Now , UserNavId = 1};
            modelBuilder.Entity<Expense>().HasData(e1);

        }
    }
}
