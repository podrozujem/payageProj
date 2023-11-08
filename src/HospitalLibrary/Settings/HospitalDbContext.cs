using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Model.map;
using HospitalLibrary.Core.Repository.specialization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DailyMeasurements> DailyMeasurements { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<MapRoom> MapRooms { get; set; }
        public DbSet<MapBuilding> MapBuildings { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<DailyMeasurements> dailyMeasurementsList { get; set; }


        public DbSet<Payment> payments { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //seed podaci           

            var b1 = new Building() { Id = 1, Name = "Ambulanta", Description = "" };
            var b2 = new Building() { Id = 2, Name = "Hirurgija", Description = "" };
            var b3 = new Building() { Id = 3, Name = "Stomatologija", Description = "" };

            var f1 = new Floor() { Id = 1, Number = 1, Description = "", Building = { } };
            var f2 = new Floor() { Id = 2, Number = 2, Description = "", Building = { } };
            var f3 = new Floor() { Id = 3, Number = 1, Description = "", Building = { } };
            var f4 = new Floor() { Id = 4, Number = 1, Description = "", Building = { } };

            var r1 = new Room() { Id = 1, Number = "101A", Building = { }, Floor = { } };
            var r2 = new Room() { Id = 2, Number = "204", Building = { }, Floor = { } };
            var r3 = new Room() { Id = 3, Number = "305B", Building = { }, Floor = { } };
            var r4 = new Room() { Id = 4, Number = "405B", Building = { }, Floor = { } };
            var r5 = new Room() { Id = 5, Number = "505B", Building = { }, Floor = { } };
            var r6 = new Room() { Id = 6, Number = "605B", Building = { }, Floor = { } };

            var me1 = new MapRoom() { Id = 1, X = 2, Y = 2, Width = 30, Height = 40, Room = { } };
            var me2 = new MapRoom() { Id = 2, X = 0, Y = 0, Width = 30, Height = 40, Room = { } };
            var me3 = new MapRoom() { Id = 3, X = 4, Y = 6, Width = 30, Height = 40, Room = { } };

            var mb1 = new MapBuilding() { Id = 1, X = 2, Y = 2, Width = 30, Height = 40, Building = { } };
            var mb2 = new MapBuilding() { Id = 2, X = 0, Y = 0, Width = 30, Height = 40, Building = { } };
            var mb3 = new MapBuilding() { Id = 3, X = 4, Y = 6, Width = 30, Height = 40, Building = { } };

            var spc1 = new Specialization() { SpecializationId = "op", SpecializationName = "Opsta praksa" };
            var spc2 = new Specialization() { SpecializationId = "spc", SpecializationName = "Specijalista" };

            var doc1 = new Doctor() { Id = 5, Email = "vojin@gmail.com", Password = "vojin", Type = UserType.DOCTOR, RequirePasswordChange = false, FirstName = "Vojin", LastName = "Dzeletovic", StartTime = System.DateTime.Parse("10:00"), EndTime = System.DateTime.Parse("10:00"), Specialization = { } };
            var doc2 = new Doctor() { Id = 6, Email = "igi@gmail.com", Password = "igi", Type = UserType.DOCTOR, RequirePasswordChange = false, FirstName = "Igor", LastName = "Miskic", StartTime = System.DateTime.Parse("10:00"), EndTime = System.DateTime.Parse("10:00"), Specialization = { } };

            var app1 = new Appointment() { AppointmentId = "app1", Doctor = { }, Patient = { }, Room = { }, Date = System.DateTime.Parse("10:00"), StartTime = System.DateTime.Parse("10:00"), EndTime = System.DateTime.Parse("10:00"), AppointmentType = AppointmentType.EXAMINATION };

            //
            modelBuilder.Entity<Building>().HasData(
                b1,
                b2,
                b3
            );

            modelBuilder.Entity<Floor>().HasData(
                f1,
                f2,
                f3,
                f4
                );

            modelBuilder.Entity<Room>().HasData(
                r1,
                r2,
                r3,
                r4,
                r5,
                r6
            );

            modelBuilder.Entity<MapRoom>().HasData(
                me1,
                me2,
                me3
                );

            modelBuilder.Entity<MapBuilding>().HasData(
                mb1,
                mb2,
                mb3
                );
            modelBuilder.Entity<Specialization>().HasData(
               spc1,
               spc2
           );
            modelBuilder.Entity<Doctor>().HasData(
                doc1,
                doc2
                );
            modelBuilder.Entity<Appointment>().HasData(
                app1
                );

            modelBuilder.Entity<User>().HasData(
                new User() { Id = 1, Email = "manager@email.com", Password = "password", Type = UserType.MANAGER, RequirePasswordChange = false },
                new User() { Id = 2, Email = "mihailoveljic3010@gmail.com", Password = "password", Type = UserType.BLOOD_BANK_MANAGER, RequirePasswordChange = true}
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 3, Email = "stefan@gmail.com", Password = "stefan", Type = UserType.PATIENT, RequirePasswordChange = false, FirstName = "Stefan", LastName = "Tosic" },
                new Patient() { Id = 4, Email = "ogi@gmail.com", Password = "ogi", Type = UserType.PATIENT, RequirePasswordChange = false, FirstName = "Ognjen", LastName = "OG" }
            );
            modelBuilder.Entity<Manager>().HasData(
               new Manager() { Id = 7, Email = "jelena@gmail.com", Password = "1234", Type = UserType.MANAGER, RequirePasswordChange = false, FirstName = "Jelena", LastName = "Dinic" },
               new Manager() { Id = 8, Email = "jjj@gmail.com", Password = "4321", Type = UserType.MANAGER, RequirePasswordChange = false, FirstName = "Neko", LastName = "Blabla" }
           );
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback() { Id = 1, Text = "Neki tekst", IsAnonymous = false, IsPublic = true, IsApproved = false, DateOfCreation = new System.DateTime(), patientId = 3 },
                new Feedback() { Id = 2, Text = "Novi fidbek", IsAnonymous = false, IsPublic = true, IsApproved = false, DateOfCreation = new System.DateTime(), patientId = 4 },
                new Feedback() { Id = 3, Text = "Neki tekst najnoviji", IsAnonymous = true, IsPublic = false, IsApproved = false, DateOfCreation = new System.DateTime(), patientId = 3 }
            );

            modelBuilder.Entity<Payment>().HasData(
            new Payment() { Id = "1",  HolderName = "Mika Mikic", Amount = 10000, Currency = "EUR", CardHolderNumber = "09099980777", ExpirationMonth = 9, ExpirationYear = 2025, CVV = 099, OrderReference = "Neka referenca", PaymentStatus = PaymentStatus.AUTHORIZED },
            new Payment() { Id = "2", HolderName = "Pera Peric", Amount = 20900, Currency = "RSD", CardHolderNumber = "34776899909", ExpirationMonth = 4, ExpirationYear = 2024, CVV = 123, OrderReference = "Neka referenca", PaymentStatus = PaymentStatus.CAPTURED },
            new Payment() { Id = "3", HolderName = "Ana Anic", Amount = 34999, Currency = "EUR", CardHolderNumber = "342221567899", ExpirationMonth = 4, ExpirationYear = 2025, CVV = 456, OrderReference = "Neka refernca", PaymentStatus = PaymentStatus.CAPTURED }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
