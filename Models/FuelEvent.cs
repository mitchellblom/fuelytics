using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Models
{
  public class FuelEvent
  {
    [Key]
    public int FuelEventId { get; set; }

    [Required]
    public int FuelPercentageChange { get; set; }

  }
}