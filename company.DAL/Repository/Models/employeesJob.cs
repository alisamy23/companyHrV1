using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("employeesJobs", Schema = "hr")]
public partial class employeesJob
{
    [Key]
    public int id { get; set; }

    public int employeeId { get; set; }

    public int jobId { get; set; }

    [ForeignKey("employeeId")]
    [InverseProperty("employeesJobs")]
    public virtual employee employee { get; set; } = null!;

    [ForeignKey("jobId")]
    [InverseProperty("employeesJobs")]
    public virtual job job { get; set; } = null!;
}
