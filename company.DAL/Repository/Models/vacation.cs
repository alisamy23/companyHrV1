using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("vacations", Schema = "hr")]
public partial class vacation
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string vacationName { get; set; } = null!;

    public double vacationCost { get; set; }

    [InverseProperty("vacation")]
    public virtual ICollection<employeesVacation> employeesVacations { get; set; } = new List<employeesVacation>();
}
