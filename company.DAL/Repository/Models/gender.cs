using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("gender", Schema = "hr")]
public partial class gender
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string genderName { get; set; } = null!;

    [InverseProperty("gender")]
    public virtual ICollection<employee> employees { get; set; } = new List<employee>();
}
