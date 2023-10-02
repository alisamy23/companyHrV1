using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("pagesGroups", Schema = "security")]
public partial class pagesGroup
{
    [Key]
    public int id { get; set; }

    public int pageId { get; set; }

    public int groupId { get; set; }

    [ForeignKey("groupId")]
    [InverseProperty("pagesGroups")]
    public virtual group group { get; set; } = null!;

    [ForeignKey("pageId")]
    [InverseProperty("pagesGroups")]
    public virtual page page { get; set; } = null!;
}
