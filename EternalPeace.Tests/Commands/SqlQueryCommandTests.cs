using EternalPeace.Command;
using EternalPeace.Commands;
using EternalPeace.Data;
using EternalPeace.Models;
using EternalPeace.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class SqlQueryCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public SqlQueryCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(options);

            _context.Patients.Add(new Patient { Id = 1, Name = "Test", Address = "A", Sex = "M", BirthDate = DateOnly.Parse("2020-01-01"), InsuranceType = "X" });
            _context.SaveChanges();
        }

        public void Dispose() => _context.Dispose();

        [Fact]
        public void Execute_UnknownTable_ReturnsError()
        {
            var cmd = new SqlQueryCommand("Unknown", "SELECT 1");
            var result = cmd.Execute(_context);
            Assert.Equal("Такой таблицы нет.", result);
        }
    }
}
