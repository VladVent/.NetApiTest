using Microsoft.EntityFrameworkCore;
using MVC.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Context
{
    public class ContextMVC : DbContext
    {
        public ContextMVC()
        { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountName)
                .IsUnique();

            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.ContactEmail)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=ApiDB;trusted_connection=true;");
        }
    }
}