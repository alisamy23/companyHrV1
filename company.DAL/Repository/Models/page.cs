using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("pages", Schema = "security")]
public partial class page
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string pageName { get; set; } = null!;

    public int parentId { get; set; }

    [StringLength(50)]
    public string? path { get; set; }

    public int? iconId { get; set; }

    [InverseProperty("parent")]
    public virtual ICollection<page> Inverseparent { get; set; } = new List<page>();

    [ForeignKey("iconId")]
    [InverseProperty("pages")]
    public virtual icon? icon { get; set; }

    [InverseProperty("page")]
    public virtual ICollection<pagesGroup> pagesGroups { get; set; } = new List<pagesGroup>();

    [ForeignKey("parentId")]
    [InverseProperty("Inverseparent")]
    public virtual page parent { get; set; } = null!;
}
