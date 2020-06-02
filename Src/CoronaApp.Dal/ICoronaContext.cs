using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CoronaApp.Dal
{
    public interface ICoronaContext:IDbContextOptions
    {
        DbSet<Location> Location { get; set; }
        DbSet<Patient> Patient { get; set; }
    }
}