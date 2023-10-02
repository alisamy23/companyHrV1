using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class EmployeesVacationVM
    {
        public int id { get; set; }
        [Required]
        public int vacationId { get; set; }
        [Required]

        public int employeeId { get; set; }
        [Required]

        [Column(TypeName = "datetime")]
        public DateTime fromDate { get; set; }
        [Required]

        [Column(TypeName = "datetime")]
        public DateTime toDate { get; set; }
    }
}
