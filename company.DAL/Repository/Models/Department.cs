using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("Departments", Schema = "hr")]
public partial class Department
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("deprtment")]
    public virtual ICollection<employee> employees { get; set; } = new List<employee>();
}
