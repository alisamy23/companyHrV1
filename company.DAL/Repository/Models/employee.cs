using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace company.DAL.Repository.Models;

[Table("employees", Schema = "hr")]
public partial class employee
{
    [Key]
    public int id { get; set; }

    [StringLength(50)]
    public string employeeName { get; set; } = null!;

    public int deprtmentId { get; set; }

    [Column(TypeName = "date")]
    public DateTime birthdate { get; set; }

    public int genderId { get; set; }

    public string nationalId { get; set; }

    [StringLength(50)]
    public string address { get; set; } = null!;

    [StringLength(50)]
    public string phone1 { get; set; } = null!;

    [StringLength(50)]
    public string? phone2 { get; set; }

    [Column(TypeName = "date")]
    public DateTime startDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? endDate { get; set; }

    public int religionId { get; set; }

    public bool? isAvtive { get; set; }

    [ForeignKey("deprtmentId")]
    [InverseProperty("employees")]
    public virtual Department deprtment { get; set; } = null!;

    [InverseProperty("employee")]
    public virtual ICollection<employeesBonu> employeesBonus { get; set; } = new List<employeesBonu>();

    [InverseProperty("employee")]
    public virtual ICollection<employeesJob> employeesJobs { get; set; } = new List<employeesJob>();

    [InverseProperty("employee")]
    public virtual ICollection<employeesVacation> employeesVacations { get; set; } = new List<employeesVacation>();

    [ForeignKey("genderId")]
    [InverseProperty("employees")]
    public virtual gender gender { get; set; } = null!;

    [ForeignKey("religionId")]
    [InverseProperty("employees")]
    public virtual religion religion { get; set; } = null!;

    [InverseProperty("idNavigation")]
    public virtual user? user { get; set; }
}
