using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public static class CommandHandler
{
    public static string HandleCommand(string request, ServiceProvider serviceProvider)
    {
        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        if (request.StartsWith("LOGIN "))
        {
            var parts = request.Substring(6).Split(' ');
            if (parts.Length != 2)
                return "ERROR: Invalid format";

            string login = parts[0];
            string password = parts[1];

            return CheckUser(login, password) ? "OK" : "FAIL";
        }
        else if (request.StartsWith("SEARCH "))
        {
            var parts = request.Substring(7).Split("||");
            if (parts.Length < 2) return "ERROR: Invalid format";

            string table = parts[0];
            string type = parts[1];
            string condition = parts.Length > 2 ? parts[2] : "";

            return Search(table, type, condition);
        }
        else if (request.StartsWith("ADD "))
        {
            var parts = request.Substring(4).Split(' ', 2);
            if (parts.Length < 2) return "ERROR: Invalid format";

            string table = parts[0];
            string[] fields = parts[1].Split('|');

            return AddFromCommand(table, fields);
        }
        else if (request.StartsWith("Успешный выход."))
        {
            return "Успешный выход.";
        }
        else if (request.StartsWith("DELETE "))
        {
            var parts = request.Split(' ', 3);
            if (parts.Length < 3 || !int.TryParse(parts[2], out int id))
                return "ERROR: Invalid format";

            return Delete(parts[1], id);
        }
        else if (request.StartsWith("CREATE_USER "))
        {
            string data = request.Substring("CREATE_USER ".Length);
            string[] parts = data.Split(' ');

            if (parts.Length != 2)
                return "ERROR: Invalid format";

            string username = parts[0].Trim();
            string password = parts[1].Trim();

            string hash = PasswordToHash(password);
            return CreateUser(username, hash, password);
        }
        else if (request.StartsWith("SQL_QUERY "))
        {
            string data = request.Substring("SQL_QUERY ".Length).Trim();

            int firstSpaceIndex = data.IndexOf(' ');
            if (firstSpaceIndex == -1)
                return "ERROR: Invalid format";

            string table = data.Substring(0, firstSpaceIndex);
            string sqlQuery = data.Substring(firstSpaceIndex + 1);

            return Sql_Query(table, sqlQuery);
        }
        else if (request.StartsWith("UPDATE "))
        {
            string[] tokens = request.Split(' ', 4);

            if (tokens.Length < 4)
                return "ERROR: Invalid format";

            string table = tokens[1];

            if (!int.TryParse(tokens[2], out int id))
                return "Ошибка: некорректный ID.";

            string condition = tokens[3];

            var (setClause, parameters, error) = SearchFiltr(condition, "2");
            if (!string.IsNullOrEmpty(error))
                return $"Ошибка в условии: {error}";

            var conditions = condition.Split(',');
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

            setClause = string.Join(", ", setParts);

            string result = Update(table, id, setClause, parameters);
            return result;
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

        var user = context.Users
            .Where(u => u.UserName == user_login)
            .FirstOrDefault();

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

                        sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate}\t{patient.InsuranceType}\t{expDate}");
                    }

                    return sb.ToString();
                }
                else if (table == "Patients" && type == "2")
                {
                    var (whereClause, parameters, error) = SearchFiltr(condition);

                    if (!string.IsNullOrEmpty(error))
                        return error;

                    try
                    {
                        var result = context.Patients
                            .Where(whereClause, parameters)
                            .ToList();

                        var sb = new StringBuilder();
                        foreach (var patient in result)
                        {
                            sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{patient.InsuranceExpDate:yyyy-MM-dd}");
                        }

                        return sb.Length == 0 ? "Пациенты не найдены по заданному условию." : sb.ToString();
                    }
                    catch
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
                        sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                    }

                    return sb.ToString();
                }
                else if (table == "Doctors" && type == "2")
                {
                    var (whereClause, parameters, error) = SearchFiltr(condition);
                    if (!string.IsNullOrEmpty(error)) return error;

                    try
                    {
                        var result = context.Doctors.Where(whereClause, parameters).ToList();
                        var sb = new StringBuilder();
                        foreach (var doctor in result)
                        {
                            sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                        }
                        return sb.Length == 0 ? "Доктора не найдены." : sb.ToString();
                    }
                    catch
                    {
                        return "Ошибка: параметр отсутствует или неверный формат.";
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
                    var (whereClause, parameters, error) = SearchFiltr(condition);
                    if (!string.IsNullOrEmpty(error)) return error;

                    try
                    {
                        var result = context.Wards.Where(whereClause, parameters).ToList();
                        var sb = new StringBuilder();
                        foreach (var ward in result)
                        {
                            sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                        }
                        return sb.Length == 0 ? "Палаты не найдены." : sb.ToString();
                    }
                    catch
                    {
                        return "Ошибка: параметр отсутствует или неверный формат.";
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
                    var (whereClause, parameters, error) = SearchFiltr(condition);
                    if (!string.IsNullOrEmpty(error)) return error;

                    try
                    {
                        var result = context.MedHistories.Where(whereClause, parameters).ToList();
                        var sb = new StringBuilder();
                        foreach (var medhistory in result)
                        {
                            string recordDate = medhistory.RecordDate.ToString("yyyy-MM-dd");
                            string dischargeDate = medhistory.DischargeDate?.ToString("yyyy-MM-dd") ?? "-";
                            sb.AppendLine($"{medhistory.Id}\t{medhistory.PatientId}\t{medhistory.Diseases}\t{medhistory.Status}\t{medhistory.DoctorId}\t{medhistory.WardId}\t{medhistory.TreatmentCost}\t{recordDate}\t{dischargeDate}");
                        }
                        return sb.Length == 0 ? "Истории болезни не найдены." : sb.ToString();
                    }
                    catch
                    {
                        return "Ошибка: параметр отсутствует или неверный формат.";
                    }
                }
            }
        }

        return "Такой таблицы нет(";
    }

    static (string conditionSql, object[] parameters, string error) SearchFiltr(string condition, string TypeFilter = "1")
    {
        if (string.IsNullOrWhiteSpace(condition) || condition.Length < 5)
            return ("", [], "Ошибка: пустое или слишком короткое условие.");

        var conditionParts = new List<string>();
        var paramValues = new List<object>();
        var operators = new[] { ">=", "<=", "!=", "=", ">", "<" };

        var conditions = condition.Split(',');

        foreach (var raw in conditions)
        {
            string cond = raw.Trim();
            string foundOperator = null;
            int opIndex = -1;

            foreach (var op in operators)
            {
                opIndex = cond.IndexOf(op, StringComparison.Ordinal);
                if (opIndex > 0)
                {
                    foundOperator = op;
                    break;
                }
            }

            if (foundOperator == null)
                return ("", [], $"Ошибка: не удалось определить оператор в '{cond}'");

            string columnName = cond.Substring(0, opIndex).Trim();
            string columnValue = cond.Substring(opIndex + foundOperator.Length).Trim();

            if (TypeFilter == "1")
            {
                if (string.IsNullOrWhiteSpace(columnName) || string.IsNullOrWhiteSpace(columnValue))
                    return ("", [], $"Ошибка разбора условия: '{cond}'");

                conditionParts.Add($"{columnName} {foundOperator} @{paramValues.Count}");
                paramValues.Add(columnValue);
            }
            else if (TypeFilter == "2")
            {
                object typedValue = columnValue;
                if (DateTime.TryParse(columnValue, out var dt))
                    typedValue = dt;
                else if (int.TryParse(columnValue, out var intVal))
                    typedValue = intVal;
                else if (bool.TryParse(columnValue, out var boolVal))
                    typedValue = boolVal;

                paramValues.Add(typedValue);
            }
        }

        string fullCondition = string.Join(" AND ", conditionParts);
        return (fullCondition, paramValues.ToArray(), "");
    }

    static string AddFromCommand(string table, string[] fields)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        if (table == "Patients")
        {
            try
            {
                int id = int.Parse(fields[0]);
                string name = fields[1];
                string address = fields[2];
                string sex = fields[3];
                DateOnly birthDate = DateOnly.Parse(fields[4]);
                string insuranceType = fields[5];
                DateOnly? insuranceExpDate = string.IsNullOrEmpty(fields[6]) ? null : DateOnly.Parse(fields[6]);

                var exists = context.Patients.Any(p => p.Id == id);
                if (exists) return "ERROR: Patient already exists";

                var patient = new Patient
                {
                    Id = id,
                    Name = name,
                    Address = address,
                    Sex = sex,
                    BirthDate = birthDate,
                    InsuranceType = insuranceType,
                    InsuranceExpDate = insuranceExpDate
                };

                context.Patients.Add(patient);
                context.SaveChanges();
                return "OK";
            }
            catch
            {
                return "ERROR: Invalid data";
            }
        }
        else if (table == "Doctors")
        {
            try
            {
                int id = int.Parse(fields[0]);
                string name = fields[1];
                string sex = fields[2];
                DateOnly birthDate = DateOnly.Parse(fields[3]);
                string speciality = fields[4];
                int workExperience = int.Parse(fields[5]);

                var exists = context.Doctors.Any(d => d.Id == id);
                if (exists) return "ERROR: Doctor already exists";

                var doctor = new Doctor
                {
                    Id = id,
                    Name = name,
                    Sex = sex,
                    BirthDate = birthDate,
                    Speciallity = speciality,
                    WorkExperience = workExperience
                };

                context.Doctors.Add(doctor);
                context.SaveChanges();
                return "OK";
            }
            catch
            {
                return "ERROR: Invalid data for Doctor";
            }
        }
        else if (table == "Wards")
        {
            try
            {
                int id = int.Parse(fields[0]);
                int numBeds = int.Parse(fields[1]);
                string wardType = fields[2];

                var exists = context.Wards.Any(w => w.Id == id);
                if (exists) return "ERROR: Ward already exists";

                var ward = new Ward
                {
                    Id = id,
                    NumBeds = numBeds,
                    WardType = wardType
                };

                context.Wards.Add(ward);
                context.SaveChanges();
                return "OK";
            }
            catch
            {
                return "ERROR: Invalid data for Ward";
            }
        }
        else if (table == "MedHistories")
        {
            try
            {
                int id = int.Parse(fields[0]);
                int patientId = int.Parse(fields[1]);
                string diseases = fields[2];
                string status = fields[3];
                int doctorId = int.Parse(fields[4]);
                int wardId = int.Parse(fields[5]);
                decimal treatmentCost = decimal.Parse(fields[6]);
                DateOnly recordDate = DateOnly.Parse(fields[7]);
                DateOnly? dischargeDate = string.IsNullOrWhiteSpace(fields[8]) ? null : DateOnly.Parse(fields[8]);

                var exists = context.MedHistories.Any(m => m.Id == id);
                if (exists) return "ERROR: MedHistory already exists";

                var medHistory = new MedHistory
                {
                    Id = id,
                    PatientId = patientId,
                    Diseases = diseases,
                    Status = status,
                    DoctorId = doctorId,
                    WardId = wardId,
                    TreatmentCost = treatmentCost,
                    RecordDate = recordDate,
                    DischargeDate = dischargeDate
                };

                context.MedHistories.Add(medHistory);
                context.SaveChanges();
                return "OK";
            }
            catch
            {
                return "ERROR: Invalid data for MedHistory";
            }
        }

        return "ERROR: Unknown table";
    }

    static string Delete(string table, int id)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        try
        {
            if (table == "Patients")
            {
                var patient = context.Patients.Find(id);
                if (patient == null)
                    return $"ERROR: Пациент с ID = {id} не найден.";

                context.Patients.Remove(patient);
            }
            else if (table == "Doctors")
            {
                var doctor = context.Doctors.Find(id);
                if (doctor == null)
                    return $"ERROR: Доктор с ID = {id} не найден.";

                context.Doctors.Remove(doctor);
            }
            else if (table == "Wards")
            {
                var ward = context.Wards.Find(id);
                if (ward == null)
                    return $"ERROR: Палата с ID = {id} не найдена.";

                context.Wards.Remove(ward);
            }
            else if (table == "MedHistories")
            {
                var history = context.MedHistories.Find(id);
                if (history == null)
                    return $"ERROR: История болезни с ID = {id} не найдена.";

                context.MedHistories.Remove(history);
            }
            else
            {
                return "ERROR: Неизвестная таблица.";
            }

            context.SaveChanges();
            return "OK";
        }
        catch (Exception ex)
        {
            return $"ERROR: {ex.Message}";
        }
    }

    static string Sql_Query(string table, string sql_query)
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
                var sb = new StringBuilder();

                try
                {
                    if (table == "Patients")
                    {
                        var result = context.Patients.FromSqlRaw(sql_query).ToList();
                        foreach (var patient in result)
                        {
                            sb.AppendLine($"{patient.Id}\t{patient.Name}\t{patient.Address}\t{patient.Sex}\t{patient.BirthDate:yyyy-MM-dd}\t{patient.InsuranceType}\t{patient.InsuranceExpDate:yyyy-MM-dd}");
                        }
                    }
                    else if (table == "Doctors")
                    {
                        var result = context.Doctors.FromSqlRaw(sql_query).ToList();
                        foreach (var doctor in result)
                        {
                            sb.AppendLine($"{doctor.Id}\t{doctor.Name}\t{doctor.Sex}\t{doctor.BirthDate:yyyy-MM-dd}\t{doctor.Speciallity}\t{doctor.WorkExperience}");
                        }
                    }
                    else if (table == "Wards")
                    {
                        var result = context.Wards.FromSqlRaw(sql_query).ToList();
                        foreach (var ward in result)
                        {
                            sb.AppendLine($"{ward.Id}\t{ward.NumBeds}\t{ward.WardType}");
                        }
                    }
                    else if (table == "MedHistories")
                    {
                        var result = context.MedHistories.FromSqlRaw(sql_query).ToList();
                        foreach (var medhistory in result)
                        {
                            sb.AppendLine($"{medhistory.Id}\t{medhistory.PatientId}\t{medhistory.Diseases}\t{medhistory.Status}\t{medhistory.DoctorId}\t{medhistory.WardId}\t{medhistory.TreatmentCost}\t{medhistory.RecordDate:yyyy-MM-dd}\t{medhistory.DischargeDate:yyyy-MM-dd}");
                        }
                    }
                    else
                    {
                        return "Такой таблицы нет.";
                    }
                }
                catch (Exception ex)
                {
                    return $"Ошибка выполнения SQL-запроса:\n{ex.Message}";
                }

                return sb.ToString();
            }
        }

        return "Такой таблицы нет.";
    }

    static string CreateUser(string username, string hash, string password)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        bool userExists = context.Users.Any(u => u.UserName == username);

        if (userExists)
        {
            return "Пользователь с таким логином уже существует.";
        }
        else
        {
            var new_user = new User
            {
                UserName = username,
                PasswordHash = hash
            };

            context.Users.Add(new_user);
            context.SaveChanges();

            return $"Создан пользователь - {username} с паролем {password} .";
        }
    }

    public static string Update(string table, int id, string setClause, object[] values)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        if (table == "Patients")
        {
            try
            {
                var assignments = setClause.Split(',')
                                           .Select((part, index) =>
                                           {
                                               var parts = part.Split('=');
                                               var column = parts[0].Trim();
                                               return $"{column} = @p{index}";
                                           })
                                           .ToList();

                var sqlSetClause = string.Join(", ", assignments);

                string sql = $"UPDATE \"Patients\" SET {sqlSetClause} WHERE \"Id\" = @id";

                var paramList = new List<object>();
                for (int i = 0; i < values.Length; i++)
                {
                    paramList.Add(new Npgsql.NpgsqlParameter($"@p{i}", values[i] ?? DBNull.Value));
                }
                paramList.Add(new Npgsql.NpgsqlParameter("@id", id));

                int updated = context.Database.ExecuteSqlRaw(sql, paramList.ToArray());

                return updated > 0 ? $"Пациент с ID = {id} обновлён." : $"Пациент с ID = {id} не найден.";
            }
            catch (Exception ex)
            {
                return "Ошибка обновления: " + ex.Message;
            }
        }

        return "Такой таблицы нет.";
    }
}