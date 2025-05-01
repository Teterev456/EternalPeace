using System;
using System.Data.Entity;
using EternalPeace.Data;
using EternalPeace.Models;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            var client1 = new Client
            {
                Id = 1,
                Name = "Иванов Пётр Васильевич",
                Address = "102А, Люблинская улица",
                Sex = "Мужчина",
                BirthDate = new DateTime(1990, 5, 1),
                InsuranceType = "-",
                InsuranceExpDate = new DateTime(2028, 3, 31)
            };

            context.Clients.Add(client1);

            context.SaveChanges();

            Console.WriteLine("Данные успешно добавлены!");

            var clients = context.Clients.ToList();

            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.Id}, Name: {client.Name}, Address: {client.Address}");
            }
        }
    }
}