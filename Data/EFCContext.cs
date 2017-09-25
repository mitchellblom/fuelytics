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

    }
}