using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class CustomEmployeeVM
    {

        public int id { get; set; }
        public string employeeName { get; set; }
        public DateTime birthdate { get; set; }
        public string nationalId { get; set; }
        public string address { get; set; } = null!;
        public string phone1 { get; set; } = null!;
        public string? phone2 { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string? genderName { get; set; }
        public string? religionName { get; set; }
        public string? deprtmentName { get; set; }
        public bool? isAvtive { get; set; }

    }
}
