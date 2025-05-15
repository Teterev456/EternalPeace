using EternalPeace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

public static class CommandHandler
{
    public static string HandleCommand(string request, ServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        if (request.StartsWith("LOGIN "))
        {
            var parts = request.Substring(6).Split(' ');
            if (parts.Length != 2)
                return "ERROR";

            string login = parts[0];
            string password = parts[1];

            return CheckUser(login, password) ? "OK" : "FAIL";
        }
        else if (request.StartsWith("SEARCH "))
        {
            var parts = request.Substring(7).Split("||");
            if (parts.Length < 2) return "ERROR";

            string table = parts[0];
            string type = parts[1];
            string condition = parts.Length > 2 ? parts[2] : "";

            return Search(table, type, condition);
        }

        return "ERROR";
    }

    static string PasswordToHash(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    static bool CheckUser(string user_login, string user_password)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        var user = context.Users.FirstOrDefault(u => u.UserName == user_login);

        string hash = PasswordToHash(user_password);
        if (user != null && hash == user.PasswordHash)
        {
            Console.WriteLine("Успешный вход.");
            return true;
        }
        else
        {
            Console.WriteLine("Неверный логин или пароль.");
            return false;
        }
    }

    static string Search(string table, string type, string? condition = null)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        var entityTypes = context.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            if (entityType.GetTableName() == table)
            {
                if (table == "Patients" && type == "1")
                {
                    var patients = context.Patients.ToList();

                    var sb = new StringBuilder();
                    foreach (var patient in patients)
                    {
                        string expDate = patient.InsuranceExpDate?.ToString("yyyy-MM-dd") ?? "-";

                        sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{expDate}");
                    }

                    return sb.ToString();
                }
                else if (table == "Patients" && type == "2")
                {
                    var patients = context.Patients.ToList();

                    if (string.IsNullOrWhiteSpace(condition) || condition.Length < 5)
                    {
                        return "Ошибка: пустое или слишком короткое условие.";
                    }

                    var conditionParts = new List<string>();
                    var paramValues = new List<object>();

                    var conditions = condition.Split(',');

                    foreach (var rawCondition in conditions)
                    {
                        string cond = rawCondition.Trim();

                        int spaceCount = 0;
                        string columnName = "";
                        string sign = "";
                        string columnValue = "";

                        for (int i = 0; i < cond.Length; i++)
                        {
                            char ch = cond[i];

                            if (ch == ' ')
                            {
                                spaceCount++;
                                continue;
                            }

                            if (spaceCount == 0)
                            {
                                columnName += ch;
                            }
                            else if (spaceCount == 1)
                            {
                                sign += ch;
                            }
                            else if (spaceCount >= 2)
                            {
                                columnValue += ch;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(columnName) &&
                            !string.IsNullOrWhiteSpace(sign) &&
                            !string.IsNullOrWhiteSpace(columnValue))
                        {
                            conditionParts.Add($"{columnName} {sign} @{paramValues.Count}");
                            paramValues.Add(columnValue);
                        }
                        else
                        {
                            return $"Ошибка разбора условия: {cond}";
                        }
                    }

                    string fullCondition = string.Join(" AND ", conditionParts);

                    try
                    {
                        var result = context.Patients
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        var sb = new StringBuilder();
                        foreach (var patient in result)
                        {
                            sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{patient.InsuranceExpDate:yyyy-MM-dd}");
                        }

                        return sb.ToString();
                    }
                    catch (Exception)
                    {
                        return "Ошибка: параметр отсутствует в таблице или неверный формат.";
                    }
                }
                if (table == "Doctors" && type == "1")
                {
                    var doctors = context.Doctors.ToList();
                    var sb = new StringBuilder();

                    foreach (var doctor in doctors)
                    {
                        sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                    }

                    return sb.ToString();
                }
                else if (table == "Doctors" && type == "2")
                {
                    Console.WriteLine("Введите условия (формат: 'Name = Иванов, Sex = Мужчина'): ");
                    string value = condition;

                    if (value.Length > 5)
                    {
                        var conditionParts = new List<string>();
                        var paramValues = new List<object>();

                        var conditions = value.Split(',');

                        foreach (var rawCondition in conditions)
                        {
                            string conditionLine = rawCondition.Trim();

                            int spaceCount = 0;
                            string columnName = "";
                            string sign = "";
                            string columnValue = "";

                            for (int i = 0; i < conditionLine.Length; i++)
                            {
                                char symb = conditionLine[i];

                                if (symb == ' ')
                                {
                                    spaceCount++;
                                    continue;
                                }

                                if (spaceCount == 0)
                                {
                                    columnName += symb;
                                }
                                else if (spaceCount == 1)
                                {
                                    sign += symb;
                                }
                                else if (spaceCount >= 2)
                                {
                                    columnValue += symb;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(columnName) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(columnValue))
                            {
                                conditionParts.Add($"{columnName} {sign} @{paramValues.Count}");
                                paramValues.Add(columnValue);
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка разбора условия: {conditionLine}");
                                return "Ошибка разбора условия";
                            }
                        }

                        string fullCondition = string.Join(" AND ", conditionParts);
                        try
                        {
                            var result = context.Doctors
                                .Where(fullCondition, paramValues.ToArray())
                                .ToList();

                            var sb = new StringBuilder();
                            foreach (var doctor in result)
                            {
                                sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                            }

                            return sb.ToString();
                        }
                        catch (Exception)
                        {
                            return "Ошибка выполнения запроса: неверное поле или значение.";
                        }
                    }
                    else
                    {
                        return "Ошибка ввода: пустое условие.";
                    }
                }
                if (table == "Wards" && type == "1")
                {
                    var wards = context.Wards.ToList();
                    var sb = new StringBuilder();

                    foreach (var ward in wards)
                    {
                        sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                    }

                    return sb.ToString();
                }
                else if (table == "Wards" && type == "2")
                {
                    if (string.IsNullOrWhiteSpace(condition) || condition.Length < 5)
                        return "Ошибка ввода: пустое или короткое условие.";

                    var conditionParts = new List<string>();
                    var paramValues = new List<object>();

                    var conditions = condition.Split(',');

                    foreach (var rawCondition in conditions)
                    {
                        string conditionLine = rawCondition.Trim();

                        int spaceCount = 0;
                        string columnName = "";
                        string sign = "";
                        string columnValue = "";

                        for (int i = 0; i < conditionLine.Length; i++)
                        {
                            char symb = conditionLine[i];

                            if (symb == ' ')
                            {
                                spaceCount++;
                                continue;
                            }

                            if (spaceCount == 0)
                            {
                                columnName += symb;
                            }
                            else if (spaceCount == 1)
                            {
                                sign += symb;
                            }
                            else if (spaceCount >= 2)
                            {
                                columnValue += symb;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(columnName) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(columnValue))
                        {
                            conditionParts.Add($"{columnName} {sign} @{paramValues.Count}");
                            paramValues.Add(columnValue);
                        }
                        else
                        {
                            return $"Ошибка разбора условия: {conditionLine}";
                        }
                    }

                    string fullCondition = string.Join(" AND ", conditionParts);
                    try
                    {
                        var result = context.Wards
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        var sb = new StringBuilder();
                        foreach (var ward in result)
                        {
                            sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                        }

                        return sb.ToString();
                    }
                    catch (Exception)
                    {
                        return "Ошибка выполнения запроса: неверное поле или значение.";
                    }
                }
                if (table == "MedHistories" && type == "1")
                {
                    var medhistories = context.MedHistories.ToList();
                    var sb = new StringBuilder();

                    foreach (var medhistory in medhistories)
                    {
                        string recordDate = medhistory.RecordDate.ToString("yyyy-MM-dd");
                        string dischargeDate = medhistory.DischargeDate?.ToString("yyyy-MM-dd") ?? "-";

                        sb.AppendLine($"{medhistory.Id}\t{medhistory.PatientId}\t{medhistory.Diseases}\t{medhistory.Status}\t{medhistory.DoctorId}\t{medhistory.WardId}\t{medhistory.TreatmentCost}\t{recordDate}\t{dischargeDate}");
                    }

                    return sb.ToString();
                }
                else if (table == "MedHistories" && type == "2")
                {
                    if (string.IsNullOrWhiteSpace(condition) || condition.Length < 5)
                        return "Ошибка ввода: пустое или короткое условие.";

                    var conditionParts = new List<string>();
                    var paramValues = new List<object>();

                    var conditions = condition.Split(',');

                    foreach (var rawCondition in conditions)
                    {
                        string conditionLine = rawCondition.Trim();

                        int spaceCount = 0;
                        string columnName = "";
                        string sign = "";
                        string columnValue = "";

                        for (int i = 0; i < conditionLine.Length; i++)
                        {
                            char symb = conditionLine[i];

                            if (symb == ' ')
                            {
                                spaceCount++;
                                continue;
                            }

                            if (spaceCount == 0)
                            {
                                columnName += symb;
                            }
                            else if (spaceCount == 1)
                            {
                                sign += symb;
                            }
                            else if (spaceCount >= 2)
                            {
                                columnValue += symb;
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(columnName) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(columnValue))
                        {
                            conditionParts.Add($"{columnName} {sign} @{paramValues.Count}");
                            paramValues.Add(columnValue);
                        }
                        else
                        {
                            return $"Ошибка разбора условия: {conditionLine}";
                        }
                    }

                    string fullCondition = string.Join(" AND ", conditionParts);
                    try
                    {
                        var result = context.MedHistories
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        var sb = new StringBuilder();
                        foreach (var medhistory in result)
                        {
                            sb.AppendLine($"{medhistory.Id}\t{medhistory.PatientId}\t{medhistory.Diseases}\t{medhistory.Status}\t{medhistory.DoctorId}\t{medhistory.WardId}\t{medhistory.TreatmentCost}\t{medhistory.RecordDate:yyyy-MM-dd}\t{medhistory.DischargeDate:yyyy-MM-dd}");
                        }

                        return sb.ToString();
                    }
                    catch (Exception)
                    {
                        return "Ошибка выполнения запроса: неверное поле или значение.";
                    }
                }
            }
        }

        return "Такой таблицы нет(";
    }
}