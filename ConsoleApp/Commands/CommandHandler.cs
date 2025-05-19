using EternalPeace.Commands;
using EternalPeace.Data;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EternalPeace.Command
{
    public static class CommandHandler
    {
        public static string HandleCommand(string request, IServiceProvider sp)
        {
            if (string.IsNullOrWhiteSpace(request))
                return "ERROR: Empty request";

            request = request.Trim();
            var tokens = request
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = tokens[0];
            string[] args = tokens.Skip(1).ToArray();

            var command = CommandFactory.CreateCommand(commandName, args);

            try
            {
                using var scope = sp.CreateScope();
                var ctx = scope.ServiceProvider
                    .GetRequiredService<EternalPeaceDbContext>();
                return command.Execute(ctx);
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }
    }
}