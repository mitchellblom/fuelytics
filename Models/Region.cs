using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Models
{
  public class Region
  {
    [Key]
    public int RegionId { get; set; }

    [Required]
    public string RegionLabel { get; set; }

  }
}