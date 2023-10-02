using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class DepartmentVM
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "برجاء ادخال إسم القسم")]
        [StringLength(50, ErrorMessage = " يجب الا  يذيد عدد الحروف عن 50")]
        public string Name { get; init; }

    }
}
