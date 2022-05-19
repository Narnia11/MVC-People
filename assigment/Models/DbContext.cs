using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment.Models
{
    public class ExDBContext : DbContext
    {
        public ExDBContext(DbContextOptions<ExDBContext> options)
       : base(options)
        { }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

    }

}
