using System;
using System.Collections.Generic;
using System.Globalization;

namespace EternalPeace.Services
{
    public static class SearchUtils
    {
        public static (string whereClause, object[] parameters, string error) BuildFilter(string? condition)
        {
            if (string.IsNullOrWhiteSpace(condition) || condition.Length < 3)
                return ("", Array.Empty<object>(), "Ошибка: пустое или слишком короткое условие.");

            var operators = new[] { ">=", "<=", "!=", "=", ">", "<" };
            var clauses = new List<string>();
            var values = new List<object>();

            var parts = condition.Split(',', StringSplitOptions.RemoveEmptyEntries);

            foreach (var raw in parts)
            {
                var cond = raw.Trim();
                string? op = null;
                int idx = -1;

                foreach (var o in operators)
                {
                    idx = cond.IndexOf(o, StringComparison.Ordinal);
                    if (idx > 0)
                    {
                        op = o;
                        break;
                    }
                }
                if (op == null)
                    return ("", Array.Empty<object>(), $"Ошибка оператора в условии: '{cond}'");

                string colRaw = cond.Substring(0, idx).Trim();
                string valRaw = cond.Substring(idx + op.Length).Trim().Trim('\'');

                if (colRaw.Length == 0 || valRaw.Length == 0)
                    return ("", Array.Empty<object>(), $"Ошибка разбора условия: '{cond}'");

                string column = ToPascalCase(colRaw);

                object parsed;

                if (DateTime.TryParseExact(
                        valRaw,
                        new[] { "yyyy-MM-dd", "yyyy-M-d", "yyyy/MM/dd", "yyyy/M/d" },
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var dt))
                {
                    parsed = DateOnly.FromDateTime(dt);
                }
                else if (int.TryParse(valRaw, out var iv))
                {
                    parsed = iv;
                }
                else if (bool.TryParse(valRaw, out var bv))
                {
                    parsed = bv;
                }
                else
                {
                    parsed = valRaw;
                }

                clauses.Add($"{column} {op} @{values.Count}");
                values.Add(parsed);
            }

            return (string.Join(" AND ", clauses), values.ToArray(), "");
        }

        private static string ToPascalCase(string s)
        {
            s = s.Trim();
            if (s.Length == 0) return s;
            return char.ToUpperInvariant(s[0]) + s.Substring(1);
        }
    }
}