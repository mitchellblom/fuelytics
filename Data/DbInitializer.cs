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

            //seeding STOPS

                var stops = new Stop []         // six stops per region following the refill stop, so 43 in total over 6 regions
                {
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Refill"    // stop 0 is a refill at the refill station in region 0
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Alpha"     // random names here from phonetic alphabet
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Bravo"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Charlie"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Delta"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Echo"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId,
                        StopLabel = "Foxtrot"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,     // 7
                        StopLabel = "Golf"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,
                        StopLabel = "Hotel"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,
                        StopLabel = "India"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,
                        StopLabel = "Juliet"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,
                        StopLabel = "Kilo"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId,
                        StopLabel = "Lima"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,     // 13
                        StopLabel = "Mike"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,
                        StopLabel = "November"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,
                        StopLabel = "Oscar"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,
                        StopLabel = "Papa"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,
                        StopLabel = "Quebec"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId,
                        StopLabel = "Romeo"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,     // 19
                        StopLabel = "Sierra"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,
                        StopLabel = "Tango"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,
                        StopLabel = "Uniform"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,
                        StopLabel = "Victor"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,
                        StopLabel = "Whiskey"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId,
                        StopLabel = "Xray"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,     // 25
                        StopLabel = "Yankee"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,
                        StopLabel = "Zulu"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,
                        StopLabel = "Alexander"     // random names from here based on most common boy names from 2012
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,
                        StopLabel = "Benjamin"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,
                        StopLabel = "Christopher"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId,
                        StopLabel = "Daniel"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,       // 31
                        StopLabel = "Ethan"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,
                        StopLabel = "Fernando"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,
                        StopLabel = "Gabriel"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,
                        StopLabel = "Henry"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,
                        StopLabel = "Isaac"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId,
                        StopLabel = "Jacob"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,      // 37
                        StopLabel = "Kevin"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,
                        StopLabel = "Liam"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,
                        StopLabel = "Mason"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,
                        StopLabel = "Noah"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,
                        StopLabel = "Owen"
                    },
                    new Stop {
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId,
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
                        StopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        FuelPercentageChange = -17, // difference between current truck fuel level and 100%, in this case arbitrary
                        FuelTimeStamp = new DateTime(2017, 9, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        FuelPercentageChange = -16, // generate random number between -5 and -17 to determine fuel depletion amount of truck
                        FuelTimeStamp = new DateTime(2017, 9, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        FuelPercentageChange = -15,
                        FuelTimeStamp = new DateTime(2017, 9, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Bravo").StopId,
                        FuelPercentageChange = -10,
                        FuelTimeStamp = new DateTime(2017, 9, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Bravo").StopId,
                        FuelPercentageChange = -9,
                        FuelTimeStamp = new DateTime(2017, 9, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Bravo").StopId,
                        FuelPercentageChange = -8,
                        FuelTimeStamp = new DateTime(2017, 9, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Charlie").StopId,
                        FuelPercentageChange = -6,
                        FuelTimeStamp = new DateTime(2017, 9, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Charlie").StopId,
                        FuelPercentageChange = -7,
                        FuelTimeStamp = new DateTime(2017, 9, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Charlie").StopId,
                        FuelPercentageChange = -8,
                        FuelTimeStamp = new DateTime(2017, 9, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Delta").StopId,
                        FuelPercentageChange = -7,
                        FuelTimeStamp = new DateTime(2017, 9, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Delta").StopId,
                        FuelPercentageChange = -12,
                        FuelTimeStamp = new DateTime(2017, 9, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Delta").StopId,
                        FuelPercentageChange = -6,
                        FuelTimeStamp = new DateTime(2017, 9, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        FuelPercentageChange = -17, // difference between current truck fuel level and 100%, in this case arbitrary
                        FuelTimeStamp = new DateTime(2017, 8, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Bravo").StopId,
                        FuelPercentageChange = -5,
                        FuelTimeStamp = new DateTime(2017, 8, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Charlie").StopId,
                        FuelPercentageChange = -6,
                        FuelTimeStamp = new DateTime(2017, 8, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Delta").StopId,
                        FuelPercentageChange = -7,
                        FuelTimeStamp = new DateTime(2017, 7, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Echo").StopId,
                        FuelPercentageChange = -8,
                        FuelTimeStamp = new DateTime(2017, 7, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Foxtrot").StopId,
                        FuelPercentageChange = -9,
                        FuelTimeStamp = new DateTime(2017, 7, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Golf").StopId,
                        FuelPercentageChange = -10,
                        FuelTimeStamp = new DateTime(2017, 6, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Hotel").StopId,
                        FuelPercentageChange = -11,
                        FuelTimeStamp = new DateTime(2017, 6, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "India").StopId,
                        FuelPercentageChange = -12,
                        FuelTimeStamp = new DateTime(2017, 6, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Juliet").StopId,
                        FuelPercentageChange = -13,
                        FuelTimeStamp = new DateTime(2017, 5, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Kilo").StopId,
                        FuelPercentageChange = -14,
                        FuelTimeStamp = new DateTime(2017, 5, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Lima").StopId,
                        FuelPercentageChange = -15,
                        FuelTimeStamp = new DateTime(2017, 5, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Mike").StopId,
                        FuelPercentageChange = -16,
                        FuelTimeStamp = new DateTime(2017, 4, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "November").StopId,
                        FuelPercentageChange = -17,
                        FuelTimeStamp = new DateTime(2017, 4, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Oscar").StopId,
                        FuelPercentageChange = -5,
                        FuelTimeStamp = new DateTime(2017, 4, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Papa").StopId,
                        FuelPercentageChange = -6,
                        FuelTimeStamp = new DateTime(2017, 3, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Quebec").StopId,
                        FuelPercentageChange = -7,
                        FuelTimeStamp = new DateTime(2017, 3, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Romeo").StopId,
                        FuelPercentageChange = -8,
                        FuelTimeStamp = new DateTime(2017, 3, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Sierra").StopId,
                        FuelPercentageChange = -9,
                        FuelTimeStamp = new DateTime(2017, 2, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Tango").StopId,
                        FuelPercentageChange = -10,
                        FuelTimeStamp = new DateTime(2017, 2, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Uniform").StopId,
                        FuelPercentageChange = -11,
                        FuelTimeStamp = new DateTime(2017, 2, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Victor").StopId,
                        FuelPercentageChange = -12,
                        FuelTimeStamp = new DateTime(2017, 1, 28, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Whiskey").StopId,
                        FuelPercentageChange = -13,
                        FuelTimeStamp = new DateTime(2017, 1, 18, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Xray").StopId,
                        FuelPercentageChange = -14,
                        FuelTimeStamp = new DateTime(2017, 1, 8, 2,3,0)
                    },
                    new FuelEvent {
                        StopId = stops.Single(n => n.StopLabel == "Yankee").StopId,
                        FuelPercentageChange = -15,
                        FuelTimeStamp = new DateTime(2016, 12, 28, 2,3,0)
                    }
                };

                foreach (FuelEvent i in fuelEvents)
                {
                    context.FuelEvent.Add(i);
                }
                context.SaveChanges();

            //seeding TRUCKS

                var trucks = new Truck []
                {
                    new Truck { 
                        CurrentFuelLevel = 100, // each truck starting the day with 100% fuel from Davidson truck yard
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId, // Stop 0 is refill in region 0
                        NextStopId = stops.Single(n => n.StopLabel == "Alpha").StopId, //
                        RegionId = regions.Single(n => n.RegionLabel == "Davidson").RegionId
                    },
                    new Truck { 
                        CurrentFuelLevel = 99,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Golf").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Sumner").RegionId
                    },
                    new Truck {
                        CurrentFuelLevel = 98,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Mike").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Wilson").RegionId
                    },
                    new Truck { 
                        CurrentFuelLevel = 97,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Sierra").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Rutherford").RegionId
                    },
                    new Truck { 
                        CurrentFuelLevel = 96,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Yankee").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Williamson").RegionId
                    },
                    new Truck { 
                        CurrentFuelLevel = 95,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Ethan").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Cheatham").RegionId
                    },
                    new Truck { 
                        CurrentFuelLevel = 94,
                        CurrentStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        NextStopId = stops.Single(n => n.StopLabel == "Kevin").StopId,
                        RegionId = regions.Single(n => n.RegionLabel == "Robertson").RegionId
                    }
                };

                foreach (Truck i in trucks)
                {
                    context.Truck.Add(i);
                }
                context.SaveChanges();

            //seeding DISPATCH EVENTS

                var dispatchEvents = new DispatchEvent []
                {
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2017, 8, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Alpha").StopId,
                        DispatchTimeStamp = new DateTime(2017, 8, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Bravo").StopId,
                        DispatchTimeStamp = new DateTime(2017, 8, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Charlie").StopId,
                        DispatchTimeStamp = new DateTime(2017, 7, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Delta").StopId,
                        DispatchTimeStamp = new DateTime(2017, 7, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 100).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Echo").StopId,
                        DispatchTimeStamp = new DateTime(2017, 7, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2017, 6, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Foxtrot").StopId,
                        DispatchTimeStamp = new DateTime(2017, 6, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Golf").StopId,
                        DispatchTimeStamp = new DateTime(2017, 6, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Hotel").StopId,
                        DispatchTimeStamp = new DateTime(2017, 5, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "India").StopId,
                        DispatchTimeStamp = new DateTime(2017, 5, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Juliet").StopId,
                        DispatchTimeStamp = new DateTime(2017, 5, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 99).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Kilo").StopId,
                        DispatchTimeStamp = new DateTime(2017, 4, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2017, 4, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Lima").StopId,
                        DispatchTimeStamp = new DateTime(2017, 4, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Mike").StopId,
                        DispatchTimeStamp = new DateTime(2017, 3, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "November").StopId,
                        DispatchTimeStamp = new DateTime(2017, 3, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Oscar").StopId,
                        DispatchTimeStamp = new DateTime(2017, 3, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Papa").StopId,
                        DispatchTimeStamp = new DateTime(2017, 3, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 98).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Quebec").StopId,
                        DispatchTimeStamp = new DateTime(2017, 3, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2017, 2, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Romeo").StopId,
                        DispatchTimeStamp = new DateTime(2017, 2, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Sierra").StopId,
                        DispatchTimeStamp = new DateTime(2017, 2, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Tango").StopId,
                        DispatchTimeStamp = new DateTime(2017, 1, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Uniform").StopId,
                        DispatchTimeStamp = new DateTime(2017, 1, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Victor").StopId,
                        DispatchTimeStamp = new DateTime(2017, 1, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 97).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Whiskey").StopId,
                        DispatchTimeStamp = new DateTime(2016, 12, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2016, 12, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Xray").StopId,
                        DispatchTimeStamp = new DateTime(2016, 12, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Yankee").StopId,
                        DispatchTimeStamp = new DateTime(2016, 11, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Zulu").StopId,
                        DispatchTimeStamp = new DateTime(2016, 11, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Alexander").StopId,
                        DispatchTimeStamp = new DateTime(2016, 11, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Benjamin").StopId,
                        DispatchTimeStamp = new DateTime(2016, 10, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 96).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Christopher").StopId,
                        DispatchTimeStamp = new DateTime(2016, 10, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2016, 10, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Daniel").StopId,
                        DispatchTimeStamp = new DateTime(2016, 9, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Ethan").StopId,
                        DispatchTimeStamp = new DateTime(2016, 9, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Fernando").StopId,
                        DispatchTimeStamp = new DateTime(2016, 9, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Gabriel").StopId,
                        DispatchTimeStamp = new DateTime(2016, 8, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Isaac").StopId,
                        DispatchTimeStamp = new DateTime(2016, 8, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 95).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Jacob").StopId,
                        DispatchTimeStamp = new DateTime(2016, 8, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Refill").StopId,
                        DispatchTimeStamp = new DateTime(2016, 7, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Kevin").StopId,
                        DispatchTimeStamp = new DateTime(2016, 7, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Liam").StopId,
                        DispatchTimeStamp = new DateTime(2016, 7, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Mason").StopId,
                        DispatchTimeStamp = new DateTime(2016, 6, 28, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Noah").StopId,
                        DispatchTimeStamp = new DateTime(2016, 6, 18, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Owen").StopId,
                        DispatchTimeStamp = new DateTime(2016, 6, 8, 1,3,0)
                    },
                    new DispatchEvent {
                        TruckTargetId = trucks.Single(n => n.CurrentFuelLevel == 94).TruckId,
                        SetNextStopId = stops.Single(n => n.StopLabel == "Parker").StopId,
                        DispatchTimeStamp = new DateTime(2016, 5, 28, 1,3,0)
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