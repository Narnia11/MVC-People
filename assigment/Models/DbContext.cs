using Microsoft.EntityFrameworkCore;
using PeopleAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p3.Models
{
    public class ExDBContext : DbContext
    {
        public ExDBContext(DbContextOptions<ExDBContext> options)
       : base(options)
        { }
        public DbSet<Person> Peoples { get; set; }

    }

}
