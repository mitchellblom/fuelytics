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
    public int CurrentFuelLevel { get; set; }

    [Required]
    public int CurrentStopId { get; set; }

    [Required]
    public int NextStopId { get; set; }

    [Required]
    public int RegionId { get; set; }

    public virtual Stop CurrentStop { get; set; }

    public virtual Stop NextStop { get; set; }

  }
}