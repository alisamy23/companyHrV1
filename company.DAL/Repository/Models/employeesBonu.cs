using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("employeesBonus", Schema = "hr")]
public partial class employeesBonu
{
    [Key]
    public int id { get; set; }

    public int bonusId { get; set; }

    public int employeeId { get; set; }

    [Column(TypeName = "date")]
    public DateTime date { get; set; }

    [ForeignKey("bonusId")]
    [InverseProperty("employeesBonus")]
    public virtual bonuss bonus { get; set; } = null!;

    [ForeignKey("employeeId")]
    [InverseProperty("employeesBonus")]
    public virtual employee employee { get; set; } = null!;
}
