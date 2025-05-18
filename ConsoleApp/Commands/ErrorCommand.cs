using EternalPeace.Data;
using System;

namespace EternalPeace.Commands
{
    public class ErrorCommand : ICommand
    {
        private readonly string _message;

        public ErrorCommand(string message)
        {
            _message = message;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            Console.WriteLine($"Ошибка: {_message}");
            return "ERROR";
        }
    }
}