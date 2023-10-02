using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("jobs", Schema = "hr")]
public partial class job
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string jobName { get; set; } = null!;

    [StringLength(50)]
    public string? salary { get; set; }

    [InverseProperty("job")]
    public virtual ICollection<employeesJob> employeesJobs { get; set; } = new List<employeesJob>();
}
