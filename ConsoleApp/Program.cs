using EternalPeace.Data;
using EternalPeace.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{

    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        Console.WriteLine("TCP-сервер запущен на 127.0.0.1:5000...");
        var listener = new TcpListener(IPAddress.Loopback, 5000);
        listener.Start();

        while (true)
        {
            using var client = listener.AcceptTcpClient();
            using var stream = client.GetStream();

            var buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine($"Получено: {request}");

            string response = CommandHandler.HandleCommand(request, serviceProvider);
            var responseData = Encoding.UTF8.GetBytes(response);
            stream.Write(responseData, 0, responseData.Length);
        }
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
                            decimal TreatmentCost = decimal.Parse(str_TreatmentCost);
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

        return "Такой таблицы нет(";
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
        return "Такой таблицы нет(";
    }
}