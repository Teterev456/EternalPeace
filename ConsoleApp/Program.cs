using EternalPeace.Command;
using EternalPeace.Data;
using EternalPeace.Models;
using EternalPeace.Services;
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
        DbContextFactory.Initialize("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1");
        Console.WriteLine("TCP-сервер запущен на 127.0.0.1:5000...");
        var listener = new TcpListener(IPAddress.Loopback, 5000);
        listener.Start();

        while (true)
        {
            using var client = listener.AcceptTcpClient();
            using var stream = client.GetStream();

            while (true)
            {
                var buffer = new byte[4096];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;

                string request = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                Console.WriteLine($"Получено: {request}");

                string response;
                try
                {
                    response = CommandHandler.HandleCommand(request, DbContextFactory.GetServiceProvider());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при обработке: {ex.Message}");
                    response = "ERROR";
                }

                Console.WriteLine($"Ответ: {response}");

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);

                if (response == "EXIT")
                {
                    Console.Clear();
                    Console.WriteLine("Клиент вышел, ждем нового входа...");
                    break;
                }
            }
        }
    }
}