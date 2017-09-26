using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFC.Models
{
  public class DispatchEvent
  {
    [Key]
    public int DispatchEventId { get; set; }

    [Required]
    public int TruckTargetId { get; set; }

    [Required]
    public int SetNextStopId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DispatchTimeStamp { get; set; }

    public virtual Truck TruckTarget { get; set; }

    public virtual Stop StopToSet { get; set; }

  }
}