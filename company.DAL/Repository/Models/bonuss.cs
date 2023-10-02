using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("bonuss", Schema = "hr")]
public partial class bonuss
{
    [Key]
    public int id { get; set; }

    public double bonusValue { get; set; }

    [StringLength(50)]
    public string bonusName { get; set; } = null!;

    public bool Bonusflag { get; set; }

    [InverseProperty("bonus")]
    public virtual ICollection<employeesBonu> employeesBonus { get; set; } = new List<employeesBonu>();
}
