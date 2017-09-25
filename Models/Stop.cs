using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Models
{
  public class Stop
  {
    [Key]
    public int StopId { get; set; }

    [Required]
    public int FuelEventId { get; set; }

    [Required]
    public int RegionId { get; set; }

    [Required]
    public int StopLabel { get; set; }

    public virtual FuelEvent FuelEvent { get; set; }
    public virtual Region Region { get; set; }


  }
}