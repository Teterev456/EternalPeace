using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EternalPeace.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EternalPeaceDbContext>
    {
        public EternalPeaceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EternalPeaceDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=eternalpeace;Username=postgres;Password=1");

            return new EternalPeaceDbContext(optionsBuilder.Options);
        }
    }
}