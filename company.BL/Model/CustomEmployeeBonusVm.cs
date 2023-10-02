using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class CustomEmployeeBonusVm
    {
        public int id { get; set; }
        public string? bonusName { get; set; }
        public string? employeeName { get; set; }
        public bool Bonusflag { get; set; }
        public double bonusValue { get; set; }
        public DateTime bonusDate { get; set; }

  
    }
}
