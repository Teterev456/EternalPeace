using EternalPeace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Services
{
    public static class DbContextFactory
    {
        private static ServiceProvider _serviceProvider;

        public static void Initialize(string connectionString)
        {
            var services = new ServiceCollection()
                .AddDbContext<EternalPeaceDbContext>(options =>
                    options.UseNpgsql(connectionString));

            _serviceProvider = services.BuildServiceProvider();
        }

        public static EternalPeaceDbContext CreateContext()
        {
            if (_serviceProvider == null)
                throw new InvalidOperationException("DbContextFactory not initialized.");

            return _serviceProvider.GetRequiredService<EternalPeaceDbContext>();
        }

        public static ServiceProvider GetServiceProvider() => _serviceProvider;
    }
}
