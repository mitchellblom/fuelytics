using Microsoft.EntityFrameworkCore;

using EFC.Models;

namespace EFC.Data
{
    public class EFCContext : DbContext
    {
        public EFCContext(DbContextOptions<EFCContext> options)
            : base(options)
        { }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<FuelEvent> FuelEvent { get; set; }
        public DbSet<DispatchEvent> DispatchEvent { get; set; }
        public DbSet<Stop> Stop { get; set; }
        public DbSet<Region> Region { get; set; }

    }
}