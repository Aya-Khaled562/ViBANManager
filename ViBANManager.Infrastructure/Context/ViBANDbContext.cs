using System.Data.Entity;
using ViBANManager.Infrastructure.Models;

namespace ViBANManager.Infrastructure.Context
{
    public class ViBANDbContext: DbContext
    {
        public ViBANDbContext():base("DefaultConnection")
        { }
        public DbSet<BankConfiguration> BankConfigurations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankConfiguration>()
                .Property(b => b.BankName)
                .IsRequired();

            modelBuilder.Entity<BankConfiguration>()
                .Property(b => b.ApiKey)
                .IsRequired();

            modelBuilder.Entity<BankConfiguration>()
                .Property(b => b.ApiSecret)
                .IsRequired();

            modelBuilder.Entity<BankConfiguration>()
                .Property(b => b.ApiBaseUrl)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
