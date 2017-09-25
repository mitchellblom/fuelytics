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

            //seeding STOPS

                var stops = new Stop []         // six stops per region following the refill stop, so 43 in total over 6 regions
                {
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Refill"    // stop 0 is a refill at the refill station in region 0
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Alpha"     // random names here from phonetic alphabet
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Bravo"
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Charlie"
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Delta"
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Echo"
                    },
                    new Stop {
                        RegionId = 0,
                        StopLabel = "Foxtrot"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "Golf"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "Hotel"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "India"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "Juliet"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "Kilo"
                    },
                    new Stop {
                        RegionId = 1,
                        StopLabel = "Lima"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "Mike"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "November"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "Oscar"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "Papa"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "Quebec"
                    },
                    new Stop {
                        RegionId = 2,
                        StopLabel = "Romeo"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Sierra"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Tango"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Uniform"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Victor"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Whiskey"
                    },
                    new Stop {
                        RegionId = 3,
                        StopLabel = "Xray"
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Yankee"
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Zulu"
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Alexander"     // random names from here based on most common boy names from 2012
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Benjamin"
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Christopher"
                    },
                    new Stop {
                        RegionId = 4,
                        StopLabel = "Daniel"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Ethan"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Fernando"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Gabriel"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Henry"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Isaac"
                    },
                    new Stop {
                        RegionId = 5,
                        StopLabel = "Jacob"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Kevin"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Liam"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Mason"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Noah"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Owen"
                    },
                    new Stop {
                        RegionId = 6,
                        StopLabel = "Parker"
                    }
                };

                foreach (Stop i in stops)
                {
                    context.Stop.Add(i);
                }
                context.SaveChanges();

            //seeding FUEL EVENTS

                var fuelEvents = new FuelEvent []
                {
                    new FuelEvent {
                        StopId = 0,
                        FuelPercentageChange = 15 // difference between current truck fuel level and 100%, in this case arbitrary
                    },
                    new FuelEvent {
                        StopId = 1,
                        FuelPercentageChange = -5 // generate random number between -5 and -17 to determine fuel depletion amount of truck
                    },
                    new FuelEvent {
                        StopId = 2,
                        FuelPercentageChange = -6
                    },
                    new FuelEvent {
                        StopId = 3,
                        FuelPercentageChange = -7
                    },
                    new FuelEvent {
                        StopId = 4,
                        FuelPercentageChange = -8
                    },
                    new FuelEvent {
                        StopId = 5,
                        FuelPercentageChange = -9
                    },
                    new FuelEvent {
                        StopId = 6,
                        FuelPercentageChange = -10
                    },
                    new FuelEvent {
                        StopId = 7,
                        FuelPercentageChange = -11
                    },
                    new FuelEvent {
                        StopId = 8,
                        FuelPercentageChange = -12
                    },
                    new FuelEvent {
                        StopId = 9,
                        FuelPercentageChange = -13
                    },
                    new FuelEvent {
                        StopId = 10,
                        FuelPercentageChange = -14
                    },
                    new FuelEvent {
                        StopId = 11,
                        FuelPercentageChange = -15
                    },
                    new FuelEvent {
                        StopId = 12,
                        FuelPercentageChange = -16
                    },
                    new FuelEvent {
                        StopId = 13,
                        FuelPercentageChange = -17
                    },
                    new FuelEvent {
                        StopId = 14,
                        FuelPercentageChange = -5
                    },
                    new FuelEvent {
                        StopId = 15,
                        FuelPercentageChange = -6
                    },
                    new FuelEvent {
                        StopId = 16,
                        FuelPercentageChange = -7
                    },
                    new FuelEvent {
                        StopId = 17,
                        FuelPercentageChange = -8
                    },
                    new FuelEvent {
                        StopId = 18,
                        FuelPercentageChange = -9
                    },
                    new FuelEvent {
                        StopId = 19,
                        FuelPercentageChange = -10
                    },
                    new FuelEvent {
                        StopId = 20,
                        FuelPercentageChange = -11
                    },
                    new FuelEvent {
                        StopId = 21,
                        FuelPercentageChange = -12
                    },
                    new FuelEvent {
                        StopId = 22,
                        FuelPercentageChange = -13
                    },
                    new FuelEvent {
                        StopId = 23,
                        FuelPercentageChange = -14
                    },
                    new FuelEvent {
                        StopId = 24,
                        FuelPercentageChange = -15
                    }
                };

                foreach (FuelEvent i in fuelEvents)
                {
                    context.FuelEvent.Add(i);
                }
                context.SaveChanges();

            //seeding DISPATCH EVENTS

                var dispatchEvents = new DispatchEvent []
                {
                    new DispatchEvent {
                        // add event attributes here
                    }
                };

                foreach (DispatchEvent i in dispatchEvents)
                {
                    context.DispatchEvent.Add(i);
                }
                context.SaveChanges();

            }
       }
    }
}