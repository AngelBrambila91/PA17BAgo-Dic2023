using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorkingWithEFCore
{
  [Keyless]
  public partial class EmployeeTerritory
  {
    [Column(TypeName = "int")]
    public int EmployeeId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar")]
    public string TerritoryId { get; set; } = null!;
  }
}
