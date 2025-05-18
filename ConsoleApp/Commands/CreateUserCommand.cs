using EternalPeace.Data;
using EternalPeace.Models;
using EternalPeace.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Commands
{
    public class CreateUserCommand : ICommand
    {
        private readonly string _username;
        private readonly string _password;

        public CreateUserCommand(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            string hash = HashingUtils.PasswordToHash(_password);

            bool userExists = context.Users.Any(u => u.UserName == _username);
            if (userExists)
            {
                return "Пользователь с таким логином уже существует.";
            }

            var newUser = new User
            {
                UserName = _username,
                PasswordHash = hash
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            return $"Создан пользователь - {_username} с паролем {_password}.";
        }
    }
}
