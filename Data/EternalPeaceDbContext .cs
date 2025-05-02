using Microsoft.EntityFrameworkCore;
using EternalPeace.Models;

namespace EternalPeace.Data
{
    public class EternalPeaceDbContext : DbContext
    {
        public EternalPeaceDbContext(DbContextOptions<EternalPeaceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedHistory> MedHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<Patient>()
                .Property(p => p.InsuranceExpDate)
                .HasColumnType("date");

            modelBuilder.Entity<Doctor>()
                .Property(p => p.BirthDate)
                .HasColumnType("date");

            modelBuilder.Entity<MedHistory>()
                .Property(p => p.RecordDate)
                .HasColumnType("date");

            modelBuilder.Entity<MedHistory>()
                .Property(p => p.DischargeDate)
                .HasColumnType("date");
        }
    }
}
