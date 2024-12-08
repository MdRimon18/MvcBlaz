using Domain.Entity.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DbContex
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSet properties for each entity you want to include in the database.
       // public DbSet<User> Users { get; set; }
      //  public DbSet<BillingPlans> BillingPlans { get; set; }
        // Optional: Override OnModelCreating to configure entity mappings.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure entity relationships, constraints, etc., here.
            //modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique(); // Example: Unique email constraint
        }
    }
}
