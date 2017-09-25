using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Models
{
  public class Truck
  {
    [Key]
    public int TruckId { get; set; }

    [Required]
    public int CurrentFuelLevel CurrentFuelLevel { get; set; } // int to represent percentage

    [Required]
    public int CurrentStopId CurrentStopId { get; set; }

  }
}