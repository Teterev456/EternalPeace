using EternalPeace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(EternalPeaceDbContext context)
        {
            return "EXIT";
        }
    }
}
