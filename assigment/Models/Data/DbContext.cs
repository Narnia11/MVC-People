using Microsoft.EntityFrameworkCore;
using assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace assignment.Models
{
    public class ExDBContext : DbContext
    {
        public ExDBContext(DbContextOptions<ExDBContext> options)
       : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonLanguage>().HasKey(sc => new { sc.PersonId, sc.LanguageId });

            modelBuilder.Entity<PersonLanguage>()
    .HasOne<Person>(sc => sc.Person)
    .WithMany(s => s.PersonLanguages)
    .HasForeignKey(sc => sc.PersonId);


            modelBuilder.Entity<PersonLanguage>()
                .HasOne<Language>(sc => sc.Language)
                .WithMany(s => s.PersonLanguages)
                .HasForeignKey(sc => sc.LanguageId);
        }

    }

}
