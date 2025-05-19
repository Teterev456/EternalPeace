using EternalPeace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EternalPeace.Services;

using Microsoft.EntityFrameworkCore;

namespace EternalPeace.Commands
{
    public class UpdateCommand : ICommand
    {
        private readonly string _table;
        private readonly int _id;
        private readonly string _condition;

        public UpdateCommand(string table, int id, string condition)
        {
            _table = table;
            _id = id;
            _condition = condition;
        }

        public string Execute(EternalPeaceDbContext context)
        {
            var (setClause, parameters, error) = SearchUtils.BuildFilter(_condition);
            if (!string.IsNullOrEmpty(error))
                return $"Ошибка в условии: {error}";

            var conditions = _condition.Split(',');
            var setParts = new List<string>();
            int paramIndex = 0;

            foreach (var raw in conditions)
            {
                string cond = raw.Trim();
                string[] ops = new[] { ">=", "<=", "!=", "=", ">", "<" };
                string foundOperator = null;
                int opIndex = -1;

                foreach (var op in ops)
                {
                    opIndex = cond.IndexOf(op, StringComparison.Ordinal);
                    if (opIndex > 0)
                    {
                        foundOperator = op;
                        break;
                    }
                }

                if (foundOperator == null)
                    return $"Ошибка: не удалось определить оператор в '{cond}'";

                string columnName = cond.Substring(0, opIndex).Trim();

                setParts.Add($"{columnName} = @p{paramIndex}");
                paramIndex++;
            }

            string sqlSetClause = string.Join(", ", setParts);

            try
            {
                string sql = $"UPDATE \"{_table}\" SET {sqlSetClause} WHERE \"Id\" = @id";

                var paramList = new List<object>();
                for (int i = 0; i < parameters.Length; i++)
                {
                    paramList.Add(new Npgsql.NpgsqlParameter($"@p{i}", parameters[i] ?? DBNull.Value));
                }
                paramList.Add(new Npgsql.NpgsqlParameter("@id", _id));

                int updated = context.Database.ExecuteSqlRaw(sql, paramList.ToArray());

                return updated > 0 ? $"{_table} с ID = {_id} обновлён." : $"{_table} с ID = {_id} не найден.";
            }
            catch (Exception ex)
            {
                return "Ошибка обновления: " + ex.Message;
            }
        }
    }
}
