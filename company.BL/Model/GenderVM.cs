using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class GenderVM
    {
        public int id { get; set; }

        [StringLength(50)]
        public string genderName { get; set; } = null!;
    }
}
