using EternalPeace.Commands;
using EternalPeace.Services;
using EternalPeace.Data;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EternalPeace.Command
{
    public class LoginCommand : ICommand
    {
        private readonly string _username;
        private readonly string _password;

        public LoginCommand(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == _username);
            if (user == null)
            {
                return "FAIL: Неверный логин или пароль.";
            }

            string hash = HashingUtils.PasswordToHash(_password);
            if (hash == user.PasswordHash)
            {
                return "OK: Успешный вход.";
            }

            return "FAIL: Неверный логин или пароль.";
        }
    }
}