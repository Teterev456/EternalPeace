using System;
using System.Linq;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using EternalPeace.Data;
using EternalPeace.Models;
using Npgsql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq.Dynamic.Core;
using System.Diagnostics;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Numerics;

class Program
{

    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        string command = "0";
        string table_name = "";
        while (command != "6")
        {
            Console.WriteLine("1 - Поиск");
            Console.WriteLine("2 - Добавить строку");
            Console.WriteLine("3 - Удалить строку");
            Console.WriteLine("4 - Изменить строку");
            Console.WriteLine("5 - SQL запрос");
            Console.WriteLine("6 - Выйти");

            Console.WriteLine("Введите номер команды: ");
            command = Console.ReadLine();

            if (command == "1")
            {
                Console.WriteLine("Введите название таблицы (с большой буквы): ");
                table_name = Console.ReadLine();
                if (table_name == "")
                {
                    Console.WriteLine("Ошибка ввода, значение не должно быть пустым.");
                }
                else
                {
                    Console.WriteLine("1 - Вывод всей таблицы");
                    Console.WriteLine("2 - Вывод с фильтрацией");

                    Console.WriteLine("Введите номер команды:");
                    string command_type = Console.ReadLine();
                    Console.WriteLine(Search(table_name, command_type));
                }
            }

            else if (command == "2")
            {
                Console.WriteLine("Введите название таблицы (с большой буквы): ");
                table_name = Console.ReadLine();
                if (table_name == "")
                {
                    Console.WriteLine("Ошибка ввода, значение не должно быть пустым.");
                }
                else
                {
                    Console.WriteLine(Add(table_name));
                }
            }

            else if (command == "3")
            {
                Console.WriteLine("Введите название таблицы (с большой буквы): ");
                table_name = Console.ReadLine();
                if (table_name == "")
                {
                    Console.WriteLine("Ошибка ввода, значение не должно быть пустым.");
                }
                else
                {
                    Console.WriteLine(Delete(table_name));
                }
            }

            else if (command == "4")
            {
                Console.WriteLine("Введите название таблицы (с большой буквы): ");
                table_name = Console.ReadLine();
                if (table_name == "")
                {
                    Console.WriteLine("Ошибка ввода, значение не должно быть пустым.");
                }
                else
                {
                    Console.WriteLine(Update(table_name));
                }
            }

            else if (command == "5")
            {
                Console.WriteLine("Введите название таблицы (с большой буквы): ");
                table_name = Console.ReadLine();
                Console.WriteLine("Введите SQL запрос (формат: SELECT * FROM \"Doctors\" WHERE sex = 'Женщина'): ");
                string sql_query = Console.ReadLine();
                if (sql_query == "")
                {
                    Console.WriteLine("Ошибка ввода, значение не должно быть пустым.");
                }
                else
                {
                    Console.WriteLine(Sql_Query(table_name, sql_query));
                }
            }

        }

    }

    static string Add(string table)
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
                if (table == "Patients")
                {
                    Console.WriteLine("Введите ID пациента: ");
                    string str_Id = Console.ReadLine();
                    Console.WriteLine("Введите имя: ");
                    string str_Name = Console.ReadLine();
                    Console.WriteLine("Введите адрес: ");
                    string str_Address = Console.ReadLine();
                    Console.WriteLine("Введите пол: ");
                    string str_Sex = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения (YYYY, MM, DD): ");
                    string str_Birhdate = Console.ReadLine();
                    Console.WriteLine("Введите тип страхования: ");
                    string str_InsuranceType = Console.ReadLine();

                    try
                    {
                        int Id = Int32.Parse(str_Id);
                        DateOnly Birhdate = DateOnly.Parse(str_Birhdate);
                        DateOnly? InsuranceExpDate;
                        if (str_InsuranceType == "-" || str_InsuranceType == "Полис ОМС")
                        {
                            InsuranceExpDate = null;
                        }
                        else
                        {
                            Console.WriteLine("Введите дату окончания страховки (YYYY, MM, DD): ");
                            string str_InsuranceExpDate = Console.ReadLine();
                            InsuranceExpDate = DateOnly.Parse(str_InsuranceExpDate);
                        }

                        var new_patient = new Patient
                        {
                            Id = Id,
                            Name = str_Name,
                            Address = str_Address,
                            Sex = str_Sex,
                            BirthDate = Birhdate,
                            InsuranceType = str_InsuranceType,
                            InsuranceExpDate = InsuranceExpDate
                        };

                        var patients = context.Patients.ToList();

                        bool patientExists = patients.Any(patient => patient.Id == Id);
                        if (patientExists)
                        {
                            Console.WriteLine("Ошибка, данный ID уже существует.");
                        }
                        else
                        {
                            context.Patients.Add(new_patient);
                            context.SaveChanges();

                            Console.WriteLine($"Успешно добавлен пациент: '{Id}', '{str_Name}'," +
                        $" '{str_Address}', '{str_Sex}', '{Birhdate}', '{str_InsuranceType}', '{InsuranceExpDate}'.");
                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка заполнения данных.");
                    }
                }

                else if (table == "Doctors")
                {
                    Console.WriteLine("Введите ID доктора: ");
                    string str_Id = Console.ReadLine();
                    Console.WriteLine("Введите имя: ");
                    string str_Name = Console.ReadLine();
                    Console.WriteLine("Введите пол: ");
                    string str_Sex = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения (YYYY, MM, DD): ");
                    string str_Birhdate = Console.ReadLine();
                    Console.WriteLine("Введите специальность: ");
                    string str_Speciallity = Console.ReadLine();
                    Console.WriteLine("Введите стаж работы (в годах): ");
                    string str_WorkExperience = Console.ReadLine();

                    try
                    {
                        int Id = Int32.Parse(str_Id);
                        DateOnly Birhdate = DateOnly.Parse(str_Birhdate);
                        int WorkExperience = Int32.Parse(str_WorkExperience);

                        var new_doctor = new Doctor
                        {
                            Id = Id,
                            Name = str_Name,
                            Sex = str_Sex,
                            BirthDate = Birhdate,
                            Speciallity = str_Speciallity,
                            WorkExperience = WorkExperience
                        };

                        var doctors = context.Doctors.ToList();

                        bool doctorExists = doctors.Any(doctor => doctor.Id == Id);
                        if (doctorExists)
                        {
                            Console.WriteLine("Ошибка, данный ID уже существует.");
                        }
                        else
                        {
                            context.Doctors.Add(new_doctor);
                            context.SaveChanges();

                            Console.WriteLine($"Успешно добавлен доктор: '{Id}', '{str_Name}'," +
                        $" '{str_Sex}', '{Birhdate}', '{str_Speciallity}', '{WorkExperience}'.");
                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка заполнения данных.");
                    }
                }

                else if (table == "Wards")
                {
                    Console.WriteLine("Введите ID палаты: ");
                    string str_Id = Console.ReadLine();
                    Console.WriteLine("Введите количество коек в палате: ");
                    string str_NumBeds = Console.ReadLine();
                    Console.WriteLine("Введите тип палаты: ");
                    string str_WardType = Console.ReadLine();

                    try
                    {
                        int Id = Int32.Parse(str_Id);
                        int NumBeds = Int32.Parse(str_NumBeds);

                        var new_ward = new Ward
                        {
                            Id = Id,
                            NumBeds = NumBeds,
                            WardType = str_WardType
                        };

                        var wards = context.Wards.ToList();

                        bool wardExists = wards.Any(ward => ward.Id == Id);
                        if (wardExists)
                        {
                            Console.WriteLine("Ошибка, данный ID уже существует.");
                        }
                        else
                        {
                            context.Wards.Add(new_ward);
                            context.SaveChanges();

                            Console.WriteLine($"Успешно добавлена палата: '{Id}', '{NumBeds}'," +
                        $" '{str_WardType}'.");
                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка заполнения данных.");
                    }
                }

                else if (table == "MedHistories")
                {
                    Console.WriteLine("Введите ID медицинской истории: ");
                    string str_Id = Console.ReadLine();
                    Console.WriteLine("Введите ID пациента: ");
                    string str_PatientId = Console.ReadLine();
                    Console.WriteLine("Введите болезнь: ");
                    string str_Diseases = Console.ReadLine();
                    Console.WriteLine("Введите статус пациента: ");
                    string str_Status = Console.ReadLine();
                    Console.WriteLine("Введите ID лечащего врача: ");
                    string str_DoctorId = Console.ReadLine();
                    Console.WriteLine("Введите ID палаты: ");
                    string str_WardId = Console.ReadLine();
                    Console.WriteLine("Введите цену лечения: ");
                    string str_TreatmentCost = Console.ReadLine();
                    Console.WriteLine("Введите дату поступления пациента: ");
                    string str_RecordDate = Console.ReadLine();
                    Console.WriteLine("Введите дату выписки пациента: ");
                    string str_DischargeDate = Console.ReadLine();

                    try
                    {
                        int Id = Int32.Parse(str_Id);
                        int PatientId = Int32.Parse(str_PatientId);
                        int DoctorId = Int32.Parse(str_DoctorId);
                        int WardId = Int32.Parse(str_WardId);
                        int TreatmentCost = Int32.Parse(str_TreatmentCost);
                        DateOnly RecordDate = DateOnly.Parse(str_RecordDate);
                        DateOnly DischargeDate = DateOnly.Parse(str_DischargeDate);

                        var new_med_history = new MedHistory
                        {
                            Id = Id,
                            PatientId = PatientId,
                            Diseases = str_Diseases,
                            Status = str_Status,
                            DoctorId = DoctorId,
                            WardId = WardId,
                            TreatmentCost = TreatmentCost,
                            RecordDate = RecordDate,
                            DischargeDate = DischargeDate
                        };

                        var medhistories = context.MedHistories.ToList();

                        bool medhistoryExists = medhistories.Any(medhistory => medhistory.Id == Id);
                        if (medhistoryExists)
                        {
                            Console.WriteLine("Ошибка, данный ID уже существует.");
                        }
                        else
                        {
                            context.MedHistories.Add(new_med_history);
                            context.SaveChanges();

                            Console.WriteLine($"Успешно добавлена медицинская история: '{Id}', '{PatientId}'," +
                        $" '{str_Diseases}', '{str_Status}', '{DoctorId}', '{WardId}', '{TreatmentCost}'" +
                        $", '{RecordDate}', '{DischargeDate}'.");

                        }
                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка заполнения данных.");
                    }
                }

                return "";
            }
        }

        return "Такой таблицы нет(";
    }

    static string Search(string table, string type)
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
                    foreach (var patient in patients)
                    {
                        Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Address: {patient.Address}, Sex: {patient.Sex}, BirthDate: {patient.BirthDate}, InsuranceType: {patient.InsuranceType}, InsuranceExpDate: {patient.InsuranceExpDate}");
                    }
                    return "";
                }
                else if (table == "Patients" && type == "2")
                {
                    var patients = context.Patients.ToList();

                    Console.WriteLine("Введите условия (формат: 'x = 10, y < 5, z >= 4'): ");
                    string value = Console.ReadLine();

                    if (value.Length > 5)
                    {
                        var conditionParts = new List<string>();
                        var paramValues = new List<object>();

                        var conditions = value.Split(',');

                        foreach (var rawCondition in conditions)
                        {
                            string condition = rawCondition.Trim();

                            int spaceCount = 0;
                            string column_name = "";
                            string sign = "";
                            string column_value = "";

                            for (int i = 0; i < condition.Length; i++)
                            {
                                char symb = condition[i];

                                if (symb == ' ')
                                {
                                    spaceCount++;
                                    continue;
                                }

                                if (spaceCount == 0)
                                {
                                    column_name += symb;
                                }
                                else if (spaceCount == 1)
                                {
                                    sign += symb;
                                }
                                else if (spaceCount >= 2)
                                {
                                    column_value += symb;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(column_name) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(column_value))
                            {
                                conditionParts.Add($"{column_name} {sign} @{paramValues.Count}");
                                paramValues.Add(column_value);
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка разбора условия: {condition}");
                                return "";
                            }
                        }

                        string fullCondition = string.Join(" AND ", conditionParts);

                        var result = context.Patients
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        foreach (var patient in result)
                        {
                            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Address: {patient.Address}, Sex: {patient.Sex}, BirthDate: {patient.BirthDate}, InsuranceType: {patient.InsuranceType}, InsuranceExpDate: {patient.InsuranceExpDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }

                    return "";
                }
                if (table == "Doctors" && type == "1")
                {
                    var doctors = context.Doctors.ToList();
                    foreach (var doctor in doctors)
                    {
                        Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Sex: {doctor.Sex}, BirthDate: {doctor.BirthDate}, Speciallity: {doctor.Speciallity}, WorkExperience: {doctor.WorkExperience}");
                    }
                    return "";
                }
                else if (table == "Doctors" && type == "2")
                {
                    var patients = context.Doctors.ToList();

                    Console.WriteLine("Введите условия (формат: 'x = 10, y < 5, z >= 4'): ");
                    string value = Console.ReadLine();

                    if (value.Length > 5)
                    {
                        var conditionParts = new List<string>();
                        var paramValues = new List<object>();

                        var conditions = value.Split(',');

                        foreach (var rawCondition in conditions)
                        {
                            string condition = rawCondition.Trim();

                            int spaceCount = 0;
                            string column_name = "";
                            string sign = "";
                            string column_value = "";

                            for (int i = 0; i < condition.Length; i++)
                            {
                                char symb = condition[i];

                                if (symb == ' ')
                                {
                                    spaceCount++;
                                    continue;
                                }

                                if (spaceCount == 0)
                                {
                                    column_name += symb;
                                }
                                else if (spaceCount == 1)
                                {
                                    sign += symb;
                                }
                                else if (spaceCount >= 2)
                                {
                                    column_value += symb;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(column_name) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(column_value))
                            {
                                conditionParts.Add($"{column_name} {sign} @{paramValues.Count}");
                                paramValues.Add(column_value);
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка разбора условия: {condition}");
                                return "";
                            }
                        }

                        string fullCondition = string.Join(" AND ", conditionParts);

                        var result = context.Doctors
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        foreach (var doctor in result)
                        {
                            Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Sex: {doctor.Sex}, BirthDate: {doctor.BirthDate}, Speciallity: {doctor.Speciallity}, WorkExperience: {doctor.WorkExperience}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }

                    return "";
                }
                if (table == "Wards" && type == "1")
                {
                    var wards = context.Wards.ToList();
                    foreach (var ward in wards)
                    {
                        Console.WriteLine($"ID: {ward.Id}, NumBeds: {ward.NumBeds}, WardType: {ward.WardType}");
                    }
                    return "";
                }
                else if (table == "Wards" && type == "2")
                {
                    var patients = context.Wards.ToList();

                    Console.WriteLine("Введите условия (формат: 'x = 10, y < 5, z >= 4'): ");
                    string value = Console.ReadLine();

                    if (value.Length > 5)
                    {
                        var conditionParts = new List<string>();
                        var paramValues = new List<object>();

                        var conditions = value.Split(',');

                        foreach (var rawCondition in conditions)
                        {
                            string condition = rawCondition.Trim();

                            int spaceCount = 0;
                            string column_name = "";
                            string sign = "";
                            string column_value = "";

                            for (int i = 0; i < condition.Length; i++)
                            {
                                char symb = condition[i];

                                if (symb == ' ')
                                {
                                    spaceCount++;
                                    continue;
                                }

                                if (spaceCount == 0)
                                {
                                    column_name += symb;
                                }
                                else if (spaceCount == 1)
                                {
                                    sign += symb;
                                }
                                else if (spaceCount >= 2)
                                {
                                    column_value += symb;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(column_name) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(column_value))
                            {
                                conditionParts.Add($"{column_name} {sign} @{paramValues.Count}");
                                paramValues.Add(column_value);
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка разбора условия: {condition}");
                                return "";
                            }
                        }

                        string fullCondition = string.Join(" AND ", conditionParts);

                        var result = context.Wards
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        foreach (var ward in result)
                        {
                            Console.WriteLine($"ID: {ward.Id}, NumBeds: {ward.NumBeds}, WardType: {ward.WardType}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }

                    return "";
                }
                if (table == "MedHistories" && type == "1")
                {
                    var medhistories = context.MedHistories.ToList();
                    foreach (var medhistory in medhistories)
                    {
                        Console.WriteLine($"ID: {medhistory.Id}, PatientID: {medhistory.PatientId}, Diseases: {medhistory.Diseases}, Status: {medhistory.Status}, DoctorId: {medhistory.DoctorId}, WardId: {medhistory.WardId}, TreatmentCost: {medhistory.TreatmentCost}, RecordDate: {medhistory.RecordDate}, DischargeDate: {medhistory.DischargeDate}");
                    }
                    return "";
                }
                else if (table == "MedHistories" && type == "2")
                {
                    var patients = context.MedHistories.ToList();

                    Console.WriteLine("Введите условия (формат: 'x = 10, y < 5, z >= 4'): ");
                    string value = Console.ReadLine();

                    if (value.Length > 5)
                    {
                        var conditionParts = new List<string>();
                        var paramValues = new List<object>();

                        var conditions = value.Split(',');

                        foreach (var rawCondition in conditions)
                        {
                            string condition = rawCondition.Trim();

                            int spaceCount = 0;
                            string column_name = "";
                            string sign = "";
                            string column_value = "";

                            for (int i = 0; i < condition.Length; i++)
                            {
                                char symb = condition[i];

                                if (symb == ' ')
                                {
                                    spaceCount++;
                                    continue;
                                }

                                if (spaceCount == 0)
                                {
                                    column_name += symb;
                                }
                                else if (spaceCount == 1)
                                {
                                    sign += symb;
                                }
                                else if (spaceCount >= 2)
                                {
                                    column_value += symb;
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(column_name) && !string.IsNullOrWhiteSpace(sign) && !string.IsNullOrWhiteSpace(column_value))
                            {
                                conditionParts.Add($"{column_name} {sign} @{paramValues.Count}");
                                paramValues.Add(column_value);
                            }
                            else
                            {
                                Console.WriteLine($"Ошибка разбора условия: {condition}");
                                return "";
                            }
                        }

                        string fullCondition = string.Join(" AND ", conditionParts);

                        var result = context.MedHistories
                            .Where(fullCondition, paramValues.ToArray())
                            .ToList();

                        foreach (var medhistory in result)
                        {
                            Console.WriteLine($"ID: {medhistory.Id}, PatientID: {medhistory.PatientId}, Diseases: {medhistory.Diseases}, Status: {medhistory.Status}, DoctorId: {medhistory.DoctorId}, WardId: {medhistory.WardId}, TreatmentCost: {medhistory.TreatmentCost}, RecordDate: {medhistory.RecordDate}, DischargeDate: {medhistory.DischargeDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода.");
                    }

                    return "";
                }
            }
        }

        return "Такой таблиц нет(";
    }

    static string Delete(string table)
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
                if (table == "Patients")
                {
                    Console.WriteLine("Введите Id пациента: ");
                    string str_deleteId = Console.ReadLine();
                    int deleteId = Int32.Parse(str_deleteId);
                    var patientDelete = context.Patients.Find(deleteId);

                    if (patientDelete != null)
                    {
                        context.Patients.Remove(patientDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Пациент с ID = {deleteId} успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Пациент с ID = {deleteId} не найден.");
                    }
                    return "";
                }
                if (table == "Doctors")
                {
                    Console.WriteLine("Введите Id доктора: ");
                    string str_deleteId = Console.ReadLine();
                    int deleteId = Int32.Parse(str_deleteId);
                    var doctorDelete = context.Doctors.Find(deleteId);

                    if (doctorDelete != null)
                    {
                        context.Doctors.Remove(doctorDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Доктор с ID = {deleteId} успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Доктор с ID = {deleteId} не найден.");
                    }
                    return "";
                }
                if (table == "Wards")
                {
                    Console.WriteLine("Введите Id палаты: ");
                    string str_deleteId = Console.ReadLine();
                    int deleteId = Int32.Parse(str_deleteId);
                    var wardDelete = context.Wards.Find(deleteId);

                    if (wardDelete != null)
                    {
                        context.Wards.Remove(wardDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Палата с ID = {deleteId} успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Палата с ID = {deleteId} не найден.");
                    }
                    return "";
                }
                if (table == "MedHistories")
                {
                    Console.WriteLine("Введите Id медицинской истории: ");
                    string str_deleteId = Console.ReadLine();
                    int deleteId = Int32.Parse(str_deleteId);
                    var medhistoryDelete = context.MedHistories.Find(deleteId);

                    if (medhistoryDelete != null)
                    {
                        context.MedHistories.Remove(medhistoryDelete);
                        context.SaveChanges();
                        Console.WriteLine($"Медицинская история с ID = {deleteId} успешно удален.");
                    }
                    else
                    {
                        Console.WriteLine($"Медицинская история с ID = {deleteId} не найден.");
                    }
                    return "";
                }
            }
        }

        return "Такой таблиц нет(";
    }

    static string Update(string table)
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
                if (table == "Patients")
                {
                    Console.WriteLine("Введите Id пациента, информацию о котором вы хотите изменить: ");
                    string str_updateId = Console.ReadLine();
                    int updateId = Int32.Parse(str_updateId);
                    var patientUpdate = context.Patients.Find(updateId);

                    if (patientUpdate != null)
                    {
                        Console.WriteLine("Введите имя: ");
                        string str_Name = Console.ReadLine();
                        Console.WriteLine("Введите адрес: ");
                        string str_Address = Console.ReadLine();
                        Console.WriteLine("Введите пол: ");
                        string str_Sex = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения (YYYY, MM, DD): ");
                        string str_Birhdate = Console.ReadLine();
                        Console.WriteLine("Введите тип страхования: ");
                        string str_InsuranceType = Console.ReadLine();

                        try
                        {
                            DateOnly Birhdate = DateOnly.Parse(str_Birhdate);
                            DateOnly? InsuranceExpDate;
                            if (str_InsuranceType == "-" || str_InsuranceType == "Полис ОМС")
                            {
                                InsuranceExpDate = null;
                            }
                            else
                            {
                                Console.WriteLine("Введите дату окончания страховки (YYYY, MM, DD): ");
                                string str_InsuranceExpDate = Console.ReadLine();
                                InsuranceExpDate = DateOnly.Parse(str_InsuranceExpDate);
                            }

                            patientUpdate.Name = str_Name;
                            patientUpdate.Address = str_Address;
                            patientUpdate.Sex = str_Sex;
                            patientUpdate.BirthDate = Birhdate;
                            patientUpdate.InsuranceType = str_InsuranceType;
                            patientUpdate.InsuranceExpDate = InsuranceExpDate;

                            context.SaveChanges();

                            Console.WriteLine($"Информация о пациенте с ID = {updateId} успешно обновлена.");
                        }


                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка заполнения данных.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Пациент с ID = {updateId} не найден.");
                    }
                    return "";
                }
                else if (table == "Doctors")
                {
                    Console.WriteLine("Введите Id доктора, информацию о котором вы хотите изменить: ");
                    string str_updateId = Console.ReadLine();
                    int updateId = Int32.Parse(str_updateId);
                    var doctorUpdate = context.Doctors.Find(updateId);

                    if (doctorUpdate != null)
                    {
                        Console.WriteLine("Введите имя: ");
                        string str_Name = Console.ReadLine();
                        Console.WriteLine("Введите пол: ");
                        string str_Sex = Console.ReadLine();
                        Console.WriteLine("Введите дату рождения (YYYY, MM, DD): ");
                        string str_Birhdate = Console.ReadLine();
                        Console.WriteLine("Введите специальность: ");
                        string str_Speciallity = Console.ReadLine();
                        Console.WriteLine("Введите стаж работы: ");
                        string str_WorkExperience = Console.ReadLine();

                        try
                        {
                            DateOnly Birhdate = DateOnly.Parse(str_Birhdate);
                            int WorkExperience = Int32.Parse(str_WorkExperience);

                            doctorUpdate.Name = str_Name;
                            doctorUpdate.Sex = str_Sex;
                            doctorUpdate.BirthDate = Birhdate;
                            doctorUpdate.Speciallity = str_Speciallity;
                            doctorUpdate.WorkExperience = WorkExperience;

                            context.SaveChanges();

                            Console.WriteLine($"Информация о докторе с ID = {updateId} успешно обновлена.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка заполнения данных.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Доктор с ID = {updateId} не найден.");
                    }
                    return "";
                }
                else if (table == "Wards")
                {
                    Console.WriteLine("Введите Id палаты, информацию о котором вы хотите изменить: ");
                    string str_updateId = Console.ReadLine();
                    int updateId = Int32.Parse(str_updateId);
                    var wardUpdate = context.Wards.Find(updateId);

                    if (wardUpdate != null)
                    {
                        Console.WriteLine("Введите количество коек в палате: ");
                        string str_NumBeds = Console.ReadLine();
                        Console.WriteLine("Введите тип палаты: ");
                        string str_WardType = Console.ReadLine();

                        try
                        {
                            int NumBeds = Int32.Parse(str_NumBeds);

                            wardUpdate.NumBeds = NumBeds;
                            wardUpdate.WardType = str_WardType;

                            context.SaveChanges();

                            Console.WriteLine($"Информация о палате с ID = {updateId} успешно обновлена.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка заполнения данных.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Палата с ID = {updateId} не найдена.");
                    }
                    return "";
                }
                else if (table == "MedHistories")
                {
                    Console.WriteLine("Введите Id медицинской истории, информацию о котором вы хотите изменить: ");
                    string str_updateId = Console.ReadLine();
                    int updateId = Int32.Parse(str_updateId);
                    var medhistoryUpdate = context.MedHistories.Find(updateId);

                    if (medhistoryUpdate != null)
                    {
                        Console.WriteLine("Введите Id пациента: ");
                        string str_PatientId = Console.ReadLine();
                        Console.WriteLine("Введите болезнь: ");
                        string str_Diseases = Console.ReadLine();
                        Console.WriteLine("Введите статус пациента: ");
                        string str_Status = Console.ReadLine();
                        Console.WriteLine("Введите Id лечащего врача: ");
                        string str_DoctorId = Console.ReadLine();
                        Console.WriteLine("Введите ID палаты: ");
                        string str_WardId = Console.ReadLine();
                        Console.WriteLine("Введите цену лечения: ");
                        string str_TreatmentCost = Console.ReadLine();
                        Console.WriteLine("Введите дату поступления пациента: ");
                        string str_RecordDate = Console.ReadLine();
                        Console.WriteLine("Введите дату выписки пациента: ");
                        string str_DischargeDate = Console.ReadLine();

                        try
                        {
                            int PatientId = Int32.Parse(str_PatientId);
                            int DoctorId = Int32.Parse(str_DoctorId);
                            int WardId = Int32.Parse(str_WardId);
                            int TreatmentCost = Int32.Parse(str_TreatmentCost);
                            DateOnly RecordDate = DateOnly.Parse(str_RecordDate);
                            DateOnly DischargeDate = DateOnly.Parse(str_DischargeDate);

                            medhistoryUpdate.PatientId = PatientId;
                            medhistoryUpdate.Diseases = str_Diseases;
                            medhistoryUpdate.Status = str_Status;
                            medhistoryUpdate.DoctorId = DoctorId;
                            medhistoryUpdate.WardId = WardId;
                            medhistoryUpdate.TreatmentCost = TreatmentCost;
                            medhistoryUpdate.RecordDate = RecordDate;
                            medhistoryUpdate.DischargeDate = DischargeDate;

                            context.SaveChanges();

                            Console.WriteLine($"Информация о медицинской истории с ID = {updateId} успешно обновлена.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка заполнения данных.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Медицинская история с ID = {updateId} не найдена.");
                    }
                    return "";
                }
            }
        }

        return "Такой таблиц нет(";
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
                if (table == "Patients")
                {
                    try
                    {
                        var result = context.Patients
                            .FromSqlRaw(sql_query)
                            .ToList();

                        foreach (var patient in result)
                        {
                            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Address: {patient.Address}, Sex: {patient.Sex}, BirthDate: {patient.BirthDate}, InsuranceType: {patient.InsuranceType}, InsuranceExpDate: {patient.InsuranceExpDate}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка выполнения SQL-запроса:");
                        Console.WriteLine(ex.Message);
                    }
                    return "";
                }
                if (table == "Doctors")
                {
                    try
                    {
                        var result = context.Doctors
                            .FromSqlRaw(sql_query)
                            .ToList();

                        foreach (var doctor in result)
                        {
                            Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}, Sex: {doctor.Sex}, BirthDate: {doctor.BirthDate}, Speciallity: {doctor.Speciallity}, WorkExperience: {doctor.WorkExperience}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка выполнения SQL-запроса:");
                        Console.WriteLine(ex.Message);
                    }
                    return "";
                }
                if (table == "Wards")
                {
                    try
                    {
                        var result = context.Wards
                            .FromSqlRaw(sql_query)
                            .ToList();

                        foreach (var ward in result)
                        {
                            Console.WriteLine($"ID: {ward.Id}, NumBeds: {ward.NumBeds}, WardType: {ward.WardType}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка выполнения SQL-запроса:");
                        Console.WriteLine(ex.Message);
                    }
                    return "";
                }
                if (table == "MedHistories")
                {
                    try
                    {
                        var result = context.MedHistories
                            .FromSqlRaw(sql_query)
                            .ToList();

                        foreach (var medhistory in result)
                        {
                            Console.WriteLine($"ID: {medhistory.Id}, PatientID: {medhistory.PatientId}, Diseases: {medhistory.Diseases}, Status: {medhistory.Status}, DoctorId: {medhistory.DoctorId}, WardId: {medhistory.WardId}, TreatmentCost: {medhistory.TreatmentCost}, RecordDate: {medhistory.RecordDate}, DischargeDate: {medhistory.DischargeDate}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка выполнения SQL-запроса:");
                        Console.WriteLine(ex.Message);
                    }
                    return "";
                }
            }
        }
        return "Такой таблиц нет(";
    }
}

