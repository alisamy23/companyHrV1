using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

public partial class icon
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string iconCode { get; set; } = null!;

    [InverseProperty("icon")]
    public virtual ICollection<page> pages { get; set; } = new List<page>();
}
