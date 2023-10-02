using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class BonusVM
    {
        [Key]
        public int id { get; set; }

        public double bonusValue { get; set; }

        [StringLength(50)]
        public string bonusName { get; set; } = null!;

        public bool Bonusflag { get; set; }
    }
}
