using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFC.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YfinderAPIdotnet2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EFCContext(serviceProvider.GetRequiredService<DbContextOptions<EFCContext>>()))
            {
                if (context.Truck.Any())
                {
                    return;
                }


            }
       }
    }
}