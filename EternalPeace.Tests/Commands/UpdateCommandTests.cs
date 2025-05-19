using EternalPeace.Command;
using EternalPeace.Commands;
using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class UpdateCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public UpdateCommandTests()
        {
            var opts = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(opts);

            _context.Patients.Add(new Patient
            {
                Id = 1,
                Name = "Test",
                Address = "Addr",
                Sex = "M",
                BirthDate = DateOnly.Parse("2000-01-01"),
                InsuranceType = "X",
                InsuranceExpDate = null
            });
            _context.SaveChanges();
        }

        public void Dispose() => _context.Dispose();

        [Fact]
        public void Execute_InvalidFilter_ReturnsBuildFilterError()
        {
            var cmd = new UpdateCommand("Patients", 1, "");
            var res = cmd.Execute(_context);
            Assert.StartsWith("Ошибка в условии:", res);
        }

        [Fact]
        public void Execute_InvalidOperator_ReturnsOperatorError()
        {
            var cmd = new UpdateCommand("Patients", 1, "NameDrX");
            var res = cmd.Execute(_context);
            Assert.Equal("Ошибка в условии: Ошибка оператора в условии: 'NameDrX'", res);
        }

        [Fact]
        public void Execute_RecordNotFound_ReturnsNotFoundOrUpdateError()
        {
            var condition = "Name == \"Test\"";
            var cmd = new UpdateCommand("Patients", 999, condition);
            var res = cmd.Execute(_context);
            Assert.StartsWith("Ошибка обновления:", res);
        }
    }
}