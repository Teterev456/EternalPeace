using EternalPeace.Command;
using EternalPeace.Data;
using Microsoft.EntityFrameworkCore;
using EternalPeace.Models;
using EternalPeace.Services;
using System;
using System.Linq;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class LoginCommandTests : IDisposable
    {
        private readonly EternalPeaceDbContext _context;

        public LoginCommandTests()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new EternalPeaceDbContext(options);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        [Fact]
        public void Execute_UserDoesNotExist_ReturnsFailMessage()
        {
            var cmd = new LoginCommand("nonexistent", "any");

            var result = cmd.Execute(_context);

            Assert.Equal("FAIL: Неверный логин или пароль.", result);
        }

        [Fact]
        public void Execute_WrongPassword_ReturnsFailMessage()
        {
            var username = "User4";
            var correctPassword = "User4123";
            var wrongPassword = "WrongPassword";

            var user = new User
            {
                UserName = username,
                PasswordHash = HashingUtils.PasswordToHash(correctPassword)
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var cmd = new LoginCommand(username, wrongPassword);

            var result = cmd.Execute(_context);

            Assert.Equal("FAIL: Неверный логин или пароль.", result);
        }

        [Fact]
        public void Execute_CorrectCredentials_ReturnsOkMessage()
        {
            var username = "User5";
            var password = "User5123";

            var user = new User
            {
                UserName = username,
                PasswordHash = HashingUtils.PasswordToHash(password)
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var cmd = new LoginCommand(username, password);

            var result = cmd.Execute(_context);

            Assert.Equal("OK: Успешный вход.", result);
        }
    }
}