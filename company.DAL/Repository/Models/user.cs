using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("users", Schema = "security")]
public partial class user
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string usetrName { get; set; } = null!;

    [StringLength(50)]
    public string userPassword { get; set; } = null!;

    public int groupId { get; set; }

    [ForeignKey("id")]
    [InverseProperty("user")]
    public virtual group id1 { get; set; } = null!;

    [ForeignKey("id")]
    [InverseProperty("user")]
    public virtual employee idNavigation { get; set; } = null!;
}
