using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class CustomEmployeesVacationVM
    {
        public int id { get; set; }
        [Required]
        public string? vacationName { get; set; }
        [Required]

        public string? employeeName { get; set; }
        [Required]

        public double vacationCost { get; set; }   
        [Required]

        public DateTime fromDate { get; set; }     
        [Required]


        public DateTime toDate { get; set; }      
           
        
    }
}
