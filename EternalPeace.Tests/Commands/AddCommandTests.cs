using System;
using System.Linq;
using EternalPeace.Command;
using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class AddCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public AddCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(options);
        }

        public void Dispose() => _context.Dispose();

        [Theory]
        [InlineData("30|Иван Иванов|123 улица АБВГ|Мужчина|1980-01-01|Полис ОМС|2025-12-31")]
        public void Add_Patient_Success(string raw)
        {
            var res = new AddCommand("Patients", new[] { raw }).Execute(_context);
            Assert.Equal("OK", res);

            var p = _context.Patients.Single();
            Assert.Equal(30, p.Id);
            Assert.Equal("Иван Иванов", p.Name);
            Assert.Equal(DateOnly.Parse("1980-01-01"), p.BirthDate);
            Assert.Equal(DateOnly.Parse("2025-12-31"), p.InsuranceExpDate);
        }

        [Theory]
        [InlineData("29|только|3|поля", "ERROR: Expected 7 fields for Patients.")]
        [InlineData("X|Имя|Адрес|Мужчина|1980-01-01|Полис ОМС|1980-01-01", "ERROR: Invalid Id for Patients.")]
        [InlineData("28|Имя|Адрес|Мужчина|не дата|Полис|1980-01-01", "ERROR: Invalid BirthDate for Patients.")]
        [InlineData("27|Имя|Адрес|Мужчина|1980-01-01|Полис|не дата", "ERROR: Invalid InsuranceExpDate for Patients.")]
        public void Add_Patient_Invalid(string raw, string expectedError)
        {
            var res = new AddCommand("Patients", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Theory]
        [InlineData("1|Имя|Адрес|Мужчина|1980-01-01|Полис|2025-01-01", "ERROR: Patient already exists")]
        public void Add_Patient_Duplicate(string raw, string expectedError)
        {
            _context.Patients.Add(new Patient
            {
                Id = 1,
                Name = "Имя",
                Address = "Адрес",
                Sex = "Мужчина",
                BirthDate = new DateOnly(1980, 1, 1),
                InsuranceType = "Полис",
                InsuranceExpDate = new DateOnly(2025, 1, 1)
            });
            _context.SaveChanges();

            var res = new AddCommand("Patients", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Theory]
        [InlineData("10|Врач|Женщина|1975-05-05|Хирург|10")]
        public void Add_Doctor_Success(string raw)
        {
            var res = new AddCommand("Doctors", new[] { raw }).Execute(_context);
            Assert.Equal("OK", res);

            var d = _context.Doctors.Single();
            Assert.Equal(10, d.Id);
            Assert.Equal("Хирург", d.Speciallity);
            Assert.Equal(10, d.WorkExperience);
        }

        [Theory]
        [InlineData("а|б|в", "ERROR: Expected 6 fields for Doctors.")]
        [InlineData("11|Врач|Женщина|не дата|Хирург|10", "ERROR: Invalid BirthDate for Doctors.")]
        [InlineData("12|Врач|Женщина|1975-05-05|Хирург|не число", "ERROR: Invalid WorkExperience for Doctors.")]
        public void Add_Doctor_Invalid(string raw, string expectedError)
        {
            var res = new AddCommand("Doctors", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Theory]
        [InlineData("1|Врач|Женщина|1975-05-05|Терапевт|10", "ERROR: Doctor already exists")]
        public void Add_Doctor_Duplicate(string raw, string expectedError)
        {
            _context.Doctors.Add(new Doctor { Id = 1, Name = "A", Sex = "M", Speciallity = "X", WorkExperience = 1 });
            _context.SaveChanges();

            var res = new AddCommand("Doctors", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Theory]
        [InlineData("10|1|VIP")]
        public void Add_Ward_Success(string raw)
        {
            var res = new AddCommand("Wards", new[] { raw }).Execute(_context);
            Assert.Equal("OK", res);

            var w = _context.Wards.Single();
            Assert.Equal(10, w.Id);
            Assert.Equal(1, w.NumBeds);
            Assert.Equal("VIP", w.WardType);
        }

        [Theory]
        [InlineData("11|2", "ERROR: Expected 3 fields for Wards.")]
        [InlineData("12|не число|ВИП", "ERROR: Invalid NumBeds for Wards.")]
        public void Add_Ward_Invalid(string raw, string expectedError)
        {
            var res = new AddCommand("Wards", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Theory]
        [InlineData("1|1|VIP", "ERROR: Ward already exists")]
        public void Add_Ward_Duplicate(string raw, string expectedError)
        {
            _context.Wards.Add(new Ward { Id = 1, NumBeds = 1, WardType = "X" });
            _context.SaveChanges();

            var res = new AddCommand("Wards", new[] { raw }).Execute(_context);
            Assert.Equal(expectedError, res);
        }

        [Fact]
        public void Add_MedHistory_Success()
        {
            _context.Patients.Add(new Patient
            {
                Id = 7,
                Name = "A",
                Address = "B",
                Sex = "M",
                BirthDate = new DateOnly(1990, 1, 1),
                InsuranceType = "X",
                InsuranceExpDate = new DateOnly(2030, 1, 1)
            });
            _context.Doctors.Add(new Doctor { Id = 8, Name = "X", Sex = "F", Speciallity = "Y", WorkExperience = 1 });
            _context.Wards.Add(new Ward { Id = 9, NumBeds = 1, WardType = "X" });
            _context.SaveChanges();

            var raw = "30|7|Гастрит|В палате|8|9|15000|2025-01-01|2025-01-10";
            var res = new AddCommand("MedHistories", new[] { raw }).Execute(_context);
            Assert.Equal("OK", res);

            var m = _context.MedHistories.Single();
            Assert.Equal(30, m.Id);
            Assert.Equal(15000.00m, m.TreatmentCost);
            Assert.Equal(DateOnly.Parse("2025-01-10"), m.DischargeDate);
        }

        [Fact]
        public void Add_MedHistory_InvalidAndDuplicate()
        {
            Assert.Equal("ERROR: Expected 9 fields for MedHistories.",
                new AddCommand("MedHistories", new[] { "1|2|3" }).Execute(_context));

            var badId = "неID|1|A|B|1|1|1.1|2025-01-01|";
            Assert.Equal("ERROR: Invalid Id for MedHistories.",
                new AddCommand("MedHistories", new[] { badId }).Execute(_context));

            _context.Patients.Add(new Patient
            {
                Id = 7,
                Name = "A",
                Address = "B",
                Sex = "M",
                BirthDate = new DateOnly(1990, 1, 1),
                InsuranceType = "X",
                InsuranceExpDate = new DateOnly(2030, 1, 1)
            });
            _context.Doctors.Add(new Doctor { Id = 8, Name = "X", Sex = "F", Speciallity = "Y", WorkExperience = 1 });
            _context.Wards.Add(new Ward { Id = 9, NumBeds = 1, WardType = "X" });
            _context.MedHistories.Add(new MedHistory { Id = 11, PatientId = 7, DoctorId = 8, WardId = 9, Diseases = "d", Status = "s", TreatmentCost = 1, RecordDate = DateOnly.FromDateTime(DateTime.Today) });
            _context.SaveChanges();

            var dup = "11|7|A|B|8|9|1|2025-01-01|";
            Assert.Equal("ERROR: MedHistory already exists",
                new AddCommand("MedHistories", new[] { dup }).Execute(_context));
        }

        [Fact]
        public void Add_UnknownTable_ReturnsError()
        {
            Assert.Equal("ERROR: Unknown table",
                new AddCommand("NoSuch", new[] { "1", "2", "3" }).Execute(_context));
        }
    }
}
