using AutoFocus_CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutoFocus_CodeFirst.Context
{
    public class AutoFocusContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rent> Rents { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<AutoFocus_CodeFirst.Models.Suggestion> Suggestions { get; set; }
    }
}