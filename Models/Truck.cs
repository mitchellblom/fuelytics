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
    public int CurrentFuelEventId { get; set; }

    [Required]
    public int NextFuelEventId { get; set; }

    [Required]
    public int RegionId { get; set; }

    public virtual FuelEvent CurrentFuelEvent { get; set; }

    public virtual FuelEvent NextFuelEvent { get; set; }

  }
}