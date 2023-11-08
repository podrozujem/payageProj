using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Payment> payments { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //seed podaci           



            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "manager@email.com", Password = "password", Type = UserType.MANAGER, RequirePasswordChange = false },
                new User() { Id = 2, Email = "mihailoveljic3010@gmail.com", Password = "password", Type = UserType.BLOOD_BANK_MANAGER, RequirePasswordChange = true}
            );

            modelBuilder.Entity<Manager>().HasData(
               new Manager() { Id = 7, Email = "jelena@gmail.com", Password = "1234", Type = UserType.MANAGER, RequirePasswordChange = false, FirstName = "Jelena", LastName = "Dinic" },
               new Manager() { Id = 8, Email = "jjj@gmail.com", Password = "4321", Type = UserType.MANAGER, RequirePasswordChange = false, FirstName = "Neko", LastName = "Blabla" }
           );

            modelBuilder.Entity<Payment>().HasData(
            new Payment() { Id = "1",  HolderName = "Mika Mikic", Amount = 10000, Currency = "EUR", CardHolderNumber = "09099980777", ExpirationMonth = 9, ExpirationYear = 2025, CVV = 099, OrderReference = "Neka referenca", PaymentStatus = PaymentStatus.AUTHORIZED },
            new Payment() { Id = "2", HolderName = "Pera Peric", Amount = 20900, Currency = "RSD", CardHolderNumber = "34776899909", ExpirationMonth = 4, ExpirationYear = 2024, CVV = 123, OrderReference = "Neka referenca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "3", HolderName = "Ana Anic", Amount = 34999, Currency = "EUR", CardHolderNumber = "342221567899", ExpirationMonth = 2, ExpirationYear = 2025, CVV = 456, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "4", HolderName = "Milica Milic", Amount = 6000, Currency = "EUR", CardHolderNumber = "12345678999", ExpirationMonth = 4, ExpirationYear = 2025, CVV = 234, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "5", HolderName = "Marko Markovic", Amount = 34999, Currency = "RSD", CardHolderNumber = "234567345", ExpirationMonth = 6, ExpirationYear = 2023, CVV = 987, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "6", HolderName = "Toma Tomic", Amount = 8999, Currency = "USD", CardHolderNumber = "764434567", ExpirationMonth = 5, ExpirationYear = 2025, CVV = 456, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.VOIDED },
            new Payment() { Id = "7", HolderName = "Sara Saric", Amount = 44449, Currency = "RSD", CardHolderNumber = "55556666", ExpirationMonth = 8, ExpirationYear = 2024, CVV = 444, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "8", HolderName = "Ankica Anci", Amount = 31200, Currency = "USD", CardHolderNumber = "999999999", ExpirationMonth = 11, ExpirationYear = 2026, CVV = 124, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.AUTHORIZED },
            new Payment() { Id = "9", HolderName = "Elez Elezovic", Amount = 36799, Currency = "RSD", CardHolderNumber = "8888888", ExpirationMonth = 11, ExpirationYear = 2026, CVV = 432, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.AUTHORIZED }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
