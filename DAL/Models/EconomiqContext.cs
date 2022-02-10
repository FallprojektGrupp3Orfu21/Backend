using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models
{
    public class EconomiqContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpensesCategory { get; set; }
        public DbSet<Recipient> Recipients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = @"Server=localhost\SQLEXPRESS;Database=FallprojektGrupp3;Integrated Security=True;";
            builder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Primary Keys
            modelbuilder.Entity<Expense>()
                .HasKey(e => e.Id);
            modelbuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelbuilder.Entity<ExpenseCategory>()
                .HasKey(ec => ec.Id);
            modelbuilder.Entity<Recipient>()
                .HasKey(r => r.Id);
            modelbuilder.Entity<Email>()
                .HasKey(c => new { c.UserNavId, c.Mail });
            //Relations
            modelbuilder.Entity<Expense>()
                .HasOne(u => u.UserNav)
                .WithMany(e => e.UserExpensesNav)
                .HasForeignKey(e => e.UserNavId)
                .OnDelete(DeleteBehavior.NoAction);
            //Does Below Work?
            //modelbuilder.Entity<User>()
            //    .HasMany(e=>e.UserExpensesNav)
            //    .WithOne(u=>u.UserNav)
            //    .OnDelete(DeleteBehavior.Cascade);
            modelbuilder.Entity<Expense>()
                .HasOne(e => e.CategoryNav)
                .WithMany(e => e.ExpensesNav)
                .HasForeignKey(e => e.CategoryNavId)
                .OnDelete(DeleteBehavior.NoAction);
            modelbuilder.Entity<ExpenseCategory>()
                .HasMany(ec => ec.UserNav)
                .WithMany(u => u.ExpensesCategoryNav);
                


            modelbuilder.Seed();
        }

    }
}
