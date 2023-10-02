using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("groups", Schema = "security")]
public partial class group
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string groupName { get; set; } = null!;

    [InverseProperty("group")]
    public virtual ICollection<pagesGroup> pagesGroups { get; set; } = new List<pagesGroup>();

    [InverseProperty("id1")]
    public virtual user? user { get; set; }
}
