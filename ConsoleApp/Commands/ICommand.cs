using EternalPeace.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalPeace.Commands
{
    public interface ICommand
    {
        string Execute(EternalPeaceDbContext context);
    }
}
