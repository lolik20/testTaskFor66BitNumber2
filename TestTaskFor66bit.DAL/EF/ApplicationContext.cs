using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskFor66bit.DAL.Models;

namespace TestTaskFor66bit.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PlayerDB> Players { get; set; }
        public DbSet<TeamDB> Teams { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }

}
