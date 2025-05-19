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
    public class CreateUserCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public CreateUserCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(options);
        }

        public void Dispose() => _context.Dispose();

        [Fact]
        public void Execute_NewUser_CreatesUserAndReturnsMessage()
        {
            var username = "newuser";
            var password = "pass123";
            var cmd = new CreateUserCommand(username, password);

            var result = cmd.Execute(_context);

            Assert.Equal($"Создан пользователь - {username} с паролем {password}.", result);

            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            Assert.NotNull(user);
            var expectedHash = HashingUtils.PasswordToHash(password);
            Assert.Equal(expectedHash, user.PasswordHash);
        }

        [Fact]
        public void Execute_ExistingUser_ReturnsDuplicateMessage()
        {
            var username = "existing";
            var passwordHash = HashingUtils.PasswordToHash("oldpass");
            _context.Users.Add(new User { UserName = username, PasswordHash = passwordHash });
            _context.SaveChanges();

            var cmd = new CreateUserCommand(username, "newpass");

            var result = cmd.Execute(_context);

            Assert.Equal("Пользователь с таким логином уже существует.", result);

            Assert.Equal(1, _context.Users.Count(u => u.UserName == username));
        }
    }
}
