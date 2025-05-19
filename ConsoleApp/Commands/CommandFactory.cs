using EternalPeace.Commands;
using System;
using System.Linq;

namespace EternalPeace.Command
{
    public static class CommandFactory
    {
        public static ICommand CreateCommand(string commandName, string[] args)
        {
            return commandName.ToUpperInvariant() switch
            {
                "LOGIN" => args.Length == 2
                    ? new LoginCommand(args[0], args[1])
                    : new ErrorCommand("LOGIN требует 2 аргумента"),

                "SEARCH" => args.Length >= 2
                    ? new SearchCommand(
                        args[0],
                        args[1],
                        args.Length > 2
                            ? string.Join(' ', args.Skip(2))
                            : null
                      )
                    : new ErrorCommand("SEARCH требует минимум 2 аргумента: table type [condition]"),

                "ADD" => args.Length >= 2
                    ? new AddCommand(args[0], args.Skip(1).ToArray())
                    : new ErrorCommand("ADD требует минимум 2 аргумента: table fields..."),

                "DELETE" => args.Length == 2 && int.TryParse(args[1], out _)
                    ? new DeleteCommand(args[0], int.Parse(args[1]))
                    : new ErrorCommand("DELETE требует 2 аргумента: table id"),

                "UPDATE" => args.Length >= 3 && int.TryParse(args[1], out _)
                    ? new UpdateCommand(args[0], int.Parse(args[1]), string.Join(' ', args.Skip(2)))
                    : new ErrorCommand("UPDATE требует минимум 3 аргумента: table id condition"),

                "SQL_QUERY" => args.Length >= 2
                    ? new SqlQueryCommand(args[0], string.Join(' ', args.Skip(1)))
                    : new ErrorCommand("SQL_QUERY требует минимум 2 аргумента: table sql_query"),
                
                "CREATE_USER" => args.Length == 2
                    ? new CreateUserCommand(args[0], args[1])
                    : new ErrorCommand("CREATE_USER требует 2 аргумента: username password"),

                "EXIT" => new ExitCommand(),
                    _ => new ErrorCommand($"Неизвестная команда: {commandName}")
            };
        }
    }
}