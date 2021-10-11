using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ITO_Test.Models;

namespace ITO_Test
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options): base(options)
        {

        }

        public DbSet<Dependencia> Dependencias { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
