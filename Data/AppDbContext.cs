using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EternalPeace.Models;

namespace EternalPeace.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base ("DBConnection")
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
