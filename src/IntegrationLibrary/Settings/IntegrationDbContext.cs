using IntegrationLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace IntegrationLibrary.Settings
{
    public class IntegrationDbContext : DbContext
    {
        public DbSet<BloodBank> BloodBanks { get; set; }

        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloodBank>().HasData(
                new BloodBank() { Id = 1, UserId = 2, CompanyName = "SveNaDev", ServerAddress = "http://localhost:8080", ApiKey = "e67553a6-1b8e-48af-a393-cd9603ac1b29" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
