using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFC.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EFC.Data
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

                //seeding REGIONS
                var regions = new Region []
                {
                    new Region { 
                        RegionLabel = "Davidson"    // stops 1-6, stop 0 also here - where the refill events occur
                    },
                    new Region { 
                        RegionLabel = "Sumner"      // stops 7-12
                    },
                    new Region { 
                        RegionLabel = "Wilson"      // stops 13-18
                    },
                    new Region { 
                        RegionLabel = "Rutherford"  // stops 19-24
                    },
                    new Region { 
                        RegionLabel = "Williamson"  // stops 25-30
                    },
                    new Region { 
                        RegionLabel = "Cheatham"    // stops 31-36
                    },
                    new Region { 
                        RegionLabel = "Robertson"   // stops 37-42
                    }
                };

                foreach (Region i in regions)
                {
                    context.Region.Add(i);
                }
                context.SaveChanges();

                //seeding TRUCKS
                var trucks = new Truck []
                {
                    new Truck { 
                        CurrentFuelLevel = 100, // each truck starting the day with 100% fuel from Davidson truck yard
                        CurrentStopId = 0, // Stop 0 is refill in region 0
                        NextStopId = 1, //
                        RegionId = 0
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 7,
                        RegionId = 1
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 13,
                        RegionId = 2
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 19,
                        RegionId = 3
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 25,
                        RegionId = 4
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 31,
                        RegionId = 5
                    },
                    new Truck { 
                        CurrentFuelLevel = 100,
                        CurrentStopId = 0,
                        NextStopId = 37,
                        RegionId = 6
                    }
                };

                foreach (Truck i in trucks)
                {
                    context.Truck.Add(i);
                }
                context.SaveChanges();

                //seeding FUEL EVENTS
                var fuelEvents = new FuelEvent []
                {
                    new FuelEvent {
                        FuelPercentageChange = 0 // generate random number between 5 and 17 to determine fuel depletion amount of truck
                    }
                };

                foreach (FuelEvent i in fuelEvents)
                {
                    context.FuelEvent.Add(i);
                }
                context.SaveChanges();

                //seeding STOPS
                var stops = new Stop []
                {
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Refill"
                    },
                    new Stop {
                        RegionId = 0
                        StopLabel = 
                    }

                };

                foreach (Stop i in stops)
                {
                    context.Stop.Add(i);
                }
                context.SaveChanges();

            }
       }
    }
}