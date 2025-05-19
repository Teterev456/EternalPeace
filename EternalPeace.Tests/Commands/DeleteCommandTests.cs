using EternalPeace.Command;
using EternalPeace.Commands;
using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class DeleteCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public DeleteCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(options);
        }

        public void Dispose() => _context.Dispose();

        [Fact]
        public void Delete_Patient_Success()
        {
            var patient = new Patient
            {
                Id = 1,
                Name = "Test",
                Address = "Addr",
                Sex = "M",
                BirthDate = DateOnly.Parse("2000-01-01"),
                InsuranceType = "Basic",
                InsuranceExpDate = null
            };
            _context.Patients.Add(patient);
            _context.SaveChanges();

            var cmd = new DeleteCommand("Patients", 1);
            var res = cmd.Execute(_context);

            Assert.Equal("OK", res);
            Assert.Null(_context.Patients.Find(1));
        }

        [Fact]
        public void Delete_Patient_NotFound()
        {
            var cmd = new DeleteCommand("Patients", 999);
            var res = cmd.Execute(_context);
            Assert.Equal("ERROR: Пациент с ID = 999 не найден.", res);
        }

        [Fact]
        public void Delete_Doctor_Success()
        {
            var doctor = new Doctor
            {
                Id = 2,
                Name = "Dr",
                Sex = "F",
                BirthDate = DateOnly.Parse("1980-05-05"),
                Speciallity = "Cardio",
                WorkExperience = 5
            };
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            var cmd = new DeleteCommand("Doctors", 2);
            var res = cmd.Execute(_context);

            Assert.Equal("OK", res);
            Assert.Null(_context.Doctors.Find(2));
        }

        [Fact]
        public void Delete_Doctor_NotFound()
        {
            var cmd = new DeleteCommand("Doctors", 999);
            var res = cmd.Execute(_context);
            Assert.Equal("ERROR: Доктор с ID = 999 не найден.", res);
        }

        [Fact]
        public void Delete_Ward_Success()
        {
            var ward = new Ward
            {
                Id = 3,
                NumBeds = 10,
                WardType = "General"
            };
            _context.Wards.Add(ward);
            _context.SaveChanges();

            var cmd = new DeleteCommand("Wards", 3);
            var res = cmd.Execute(_context);

            Assert.Equal("OK", res);
            Assert.Null(_context.Wards.Find(3));
        }

        [Fact]
        public void Delete_Ward_NotFound()
        {
            var cmd = new DeleteCommand("Wards", 999);
            var res = cmd.Execute(_context);
            Assert.Equal("ERROR: Палата с ID = 999 не найдена.", res);
        }

        [Fact]
        public void Delete_MedHistory_Success()
        {
            var patient = new Patient { Id = 4, Name = "A", Address = "B", Sex = "M", BirthDate = DateOnly.Parse("2000-01-01"), InsuranceType = "X" };
            var doctor = new Doctor { Id = 5, Name = "D", Sex = "F", BirthDate = DateOnly.Parse("1980-01-01"), Speciallity = "Y", WorkExperience = 3 };
            var ward = new Ward { Id = 6, NumBeds = 5, WardType = "X" };
            _context.Patients.Add(patient);
            _context.Doctors.Add(doctor);
            _context.Wards.Add(ward);
            _context.MedHistories.Add(new MedHistory
            {
                Id = 7,
                PatientId = 4,
                DoctorId = 5,
                WardId = 6,
                Diseases = "Flu",
                Status = "Active",
                TreatmentCost = 500,
                RecordDate = DateOnly.Parse("2024-01-01")
            });
            _context.SaveChanges();

            var cmd = new DeleteCommand("MedHistories", 7);
            var res = cmd.Execute(_context);

            Assert.Equal("OK", res);
            Assert.Null(_context.MedHistories.Find(7));
        }

        [Fact]
        public void Delete_MedHistory_NotFound()
        {
            var cmd = new DeleteCommand("MedHistories", 999);
            var res = cmd.Execute(_context);
            Assert.Equal("ERROR: История болезни с ID = 999 не найдена.", res);
        }

        [Fact]
        public void Delete_UnknownTable_ReturnsError()
        {
            var cmd = new DeleteCommand("Unknown", 1);
            var res = cmd.Execute(_context);
            Assert.Equal("ERROR: Неизвестная таблица.", res);
        }
    }
}