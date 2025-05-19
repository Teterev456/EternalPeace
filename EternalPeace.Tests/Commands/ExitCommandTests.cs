using EternalPeace.Command;
using EternalPeace.Commands;
using EternalPeace.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EternalPeace.Tests.Commands
{
    public class ExitCommandTests
    {
        [Fact]
        public void Execute_ReturnsEXIT()
        {
            var options = new DbContextOptionsBuilder<EternalPeaceDbContext>()
                .UseInMemoryDatabase("ExitTest")
                .Options;
            using var context = new EternalPeaceDbContext(options);

            var cmd = new ExitCommand();
            var result = cmd.Execute(context);

            Assert.Equal("EXIT", result);
        }
    }
}
