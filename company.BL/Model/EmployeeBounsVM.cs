using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class EmployeeBounsVM
    {
        public int id { get; set; }
        [Required]
        public int bonusId { get; set; }
        [Required]

        public int employeeId { get; set; }
        [Required]

        public DateTime date { get; set; }
    }
}
