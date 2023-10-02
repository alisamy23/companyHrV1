using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("employeesVacations", Schema = "hr")]
public partial class employeesVacation
{
    [Key]
    public int id { get; set; }

    public int vacationId { get; set; }

    public int employeeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime fromDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime toDate { get; set; }

    [ForeignKey("employeeId")]
    [InverseProperty("employeesVacations")]
    public virtual employee employee { get; set; } = null!;

    [ForeignKey("vacationId")]
    [InverseProperty("employeesVacations")]
    public virtual vacation vacation { get; set; } = null!;
}
