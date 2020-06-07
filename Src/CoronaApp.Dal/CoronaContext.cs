using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Collections.Generic;

namespace CoronaApp.Dal
{
    public class CoronaContext : DbContext//,ICoronaContext
    {
        public CoronaContext(DbContextOptions<CoronaContext> options): base(options) 
        { 

        }
        public CoronaContext()
        { }

        public DbSet<Location> Location { get; set; }
        public DbSet<Patient> Patient { get; set; }

        
        //public IEnumerable<IDbContextOptionsExtension> Extensions => throw new System.NotImplementedException();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder
        //        .UseSqlServer("Data Source = myComputer; Initial Catalog = CoronaApp; Integrated Security = True");
        //    }
        //}

        //TExtension IDbContextOptions.FindExtension<TExtension>()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
