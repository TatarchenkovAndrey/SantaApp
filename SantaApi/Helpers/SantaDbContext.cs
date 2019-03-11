using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SantaApi.Helpers.Configurations;
using SantaApi.Models;

namespace SantaApi.Helpers
{
    public class SantaDbContext : DbContext
    {
        public SantaDbContext(DbContextOptions<SantaDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeeCard> EmployeeCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeCardConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
    
   
}