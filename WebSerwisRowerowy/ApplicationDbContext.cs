
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSerwisRowerowy.Entities;
using WebSerwisRowerowy.Models;

namespace WebSerwisRowerowy
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
            base(options){ }

        public virtual DbSet<Klient> Klienci { get; set; }
        public virtual DbSet<MetodPlatnosci> MetodPlatnosci { get; set; }
        public virtual DbSet<Pracownik> Pracownicy { get; set; }
        public virtual DbSet<Usluga> Uslugi { get; set; }
        public virtual DbSet<UslugaZlecenie> UslugiUzyte { get; set; }
        public virtual DbSet<Zlecenie> Zlecenia { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Statusy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired(); 

            modelBuilder.Entity<Role>()
                .Property(u => u.Nazwa)
                .IsRequired();

            modelBuilder.Entity<Usluga>()
                .Property(u => u.CenaNetto)
                .HasColumnType("decimal(12,2)");

            modelBuilder.Entity<Usluga>()
                .Property(u => u.PodatekVAT)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Zlecenie>()
                .Property(u => u.CenaBrutto)
                .HasColumnType("decimal(12,2)");
        }

    }
}
