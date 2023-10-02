using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("religions", Schema = "hr")]
public partial class religion
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string? religionName { get; set; }

    [InverseProperty("religion")]
    public virtual ICollection<employee> employees { get; set; } = new List<employee>();
}
