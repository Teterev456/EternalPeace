using EternalPeace.Command;
using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Tests.Commands
{
    public class SearchCommandTests
    {
        private EternalPeaceDbContext _context;

        public SearchCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new EternalPeaceDbContext(options);
        }

        [Fact]
        public void SearchPatients_ReturnsAll()
        {
            _context.Patients.Add(new Patient { Id = 1, Name = "A", Address = "Addr", Sex = "M", BirthDate = DateOnly.Parse("2000-01-01"), InsuranceType = "Basic" });
            _context.SaveChanges();

            var cmd = new SearchCommand("Patients", "1");
            var result = cmd.Execute(_context);

            Assert.Contains("1\tA\tAddr\tM\t2000-01-01\tBasic", result);
        }

        [Fact]
        public void SearchDoctors_FilterByName()
        {
            _context.Doctors.Add(new Doctor { Id = 1, Name = "DrX", Sex = "F", BirthDate = DateOnly.Parse("1990-05-05"), Speciallity = "Cardio", WorkExperience = 10 });
            _context.SaveChanges();

            var cmd = new SearchCommand("Doctors", "2", "Name.Equals(\"DrX\")");
            var result = cmd.Execute(_context);

            Assert.Contains("DrX", result);
            Assert.DoesNotContain("Доктора не найдены", result);
        }

        public void SearchWards_InvalidCondition_ReturnsError()
        {
            var cmd = new SearchCommand("Wards", "2", "invalid syntax");
            var result = cmd.Execute(_context);

            Assert.StartsWith("Ошибка оператора в условии:", result);
        }

        [Fact]
        public void SearchMedHistories_NoMatchCondition()
        {
            _context.MedHistories.Add(new MedHistory
            {
                Id = 1,
                PatientId = 1,
                Diseases = "Flu",
                Status = "Recovered",
                DoctorId = 2,
                WardId = 3,
                TreatmentCost = 1000,
                RecordDate = DateOnly.Parse("2024-01-01")
            });
            _context.SaveChanges();

            var cmd = new SearchCommand("MedHistories", "2", "Diseases == \"COVID\"");
            var result = cmd.Execute(_context);

            Assert.Equal("Истории болезни не найдены.", result);
        }

        [Fact]
        public void Search_InvalidTable_ReturnsError()
        {
            var cmd = new SearchCommand("UnknownTable", "1");
            var result = cmd.Execute(_context);

            Assert.Equal("Такой таблицы нет.", result);
        }

        [Fact]
        public void Search_InvalidType_ReturnsError()
        {
            var cmd = new SearchCommand("Patients", "999");
            var result = cmd.Execute(_context);

            Assert.Equal("Неверный тип запроса.", result);
        }
    }
}
