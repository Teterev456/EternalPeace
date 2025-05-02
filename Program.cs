using System;
using System.Linq;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using EternalPeace.Data;
using EternalPeace.Models;
using Npgsql;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<EternalPeaceDbContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1"))
            .BuildServiceProvider();

        using var context = serviceProvider.GetRequiredService<EternalPeaceDbContext>();

        var patient1 = new Patient
        {
            Id = 1,
            Name = "Иванов Пётр Васильевич",
            Address = "102А, Люблинская улица",
            Sex = "Мужчина",
            BirthDate = new DateOnly(1990, 5, 1),
            InsuranceType = "Полис ОМС"
        };

        var patient2 = new Patient
        {
            Id = 2,
            Name = "Денисова Амина Данииловна",
            Address = "24, Новозаводская улица",
            Sex = "Женщина",
            BirthDate = new DateOnly(1997, 9, 14),
            InsuranceType = "Полис ОМС"
        };

        var patient3 = new Patient
        {
            Id = 3,
            Name = "Лаврентьев Даниил Кириллович",
            Address = "47, Деревня Чепелево",
            Sex = "Мужчина",
            BirthDate = new DateOnly(2001, 1, 3),
            InsuranceType = "ДМС",
            InsuranceExpDate = new DateOnly(2027, 12, 31)
        };


        var patient4 = new Patient
        {
            Id = 4,
            Name = "Жуков Алексей Матвеевич",
            Address = "47, 2, Автозаводская улица",
            Sex = "Мужчина",
            BirthDate = new DateOnly(1976, 8, 15),
            InsuranceType = "Полис ОМС",
            InsuranceExpDate = null
        };

        var patient5 = new Patient
        {
            Id = 5,
            Name = "Токарева София Тимофеевна",
            Address = "21А, проспект 50 лет Октября",
            Sex = "Женщина",
            BirthDate = new DateOnly(1988, 2, 28),
            InsuranceType = "Полис ОМС",
            InsuranceExpDate = null
        };

        var patient6 = new Patient
        {
            Id = 6,
            Name = "Денисова Амина Данииловна",
            Address = "40Ж, Проезжая улица",
            Sex = "Женщина",
            BirthDate = new DateOnly(1993, 6, 11),
            InsuranceType = "Полис ОМС",
            InsuranceExpDate = null
        };


        context.Patients.Add(patient1);
        context.Patients.Add(patient2);
        context.Patients.Add(patient3);
        context.Patients.Add(patient4);
        context.Patients.Add(patient5);
        context.Patients.Add(patient6);

        context.SaveChanges();

        Console.WriteLine("Данные успешно добавлены!");

        var patients = context.Patients.ToList();

        foreach (var patient in patients)
        {
            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Address: {patient.Address}, Sex: {patient.Sex}, BirthDate: {patient.BirthDate}, InsuranceType: {patient.InsuranceType}, InsuranceExpDate: {patient.InsuranceExpDate}");
        }

    }
}