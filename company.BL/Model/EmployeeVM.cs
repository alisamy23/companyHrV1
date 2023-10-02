using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Model
{
    public class EmployeeVM
    {
        public int id { get; set; }

        [Required(ErrorMessage = "برجاء ادخال إسم الموظف")]
        [StringLength(50, ErrorMessage = " يجب الا  يذيد عدد الحروف عن 50")]
        public string employeeName { get; set; }
        [Required]
        public int deprtmentId { get; set; }
        [Required]

        [Column(TypeName = "date")]
        public DateTime birthdate { get; set; }
        [Required]
        public int genderId { get; set; }
        [Required]
        [RegularExpression("(?<BirthMillennium>[23])\x20?(?:(?<BirthYear>[0-9]{2})\x20?(?:(?:(?<BirthMonth>0[13578]|1[02])\x20?(?<BirthDay>0[1-9]|[12][0-9]|3[01]))\x20?|(?:(?<BirthMonth>0[469]|11)\x20?(?<BirthDay>0[1-9]|[12][0-9]|30))\x20?|(?:(?<BirthMonth>02)\x20?(?<BirthDay>0[1-9]|1[0-9]|2[0-8]))\x20?)|(?:(?<BirthYear>04|08|[2468][048]|[13579][26]|(?<=3)00)\x20?(?<BirthMonth>02)\x20?(?<BirthDay>29)\x20?))(?<ProvinceCode>0[1-34]|[12][1-9]|3[1-5]|88)\x20?(?<RegistryDigit>[0-9]{3}(?<GenderDigit>[0-9]))\x20?(?<CheckDigit>[0-9])", ErrorMessage = "The nationalId '' is invalid.")]

        public string nationalId { get; set; }
        [Required]

        [StringLength(50)]
        public string address { get; set; } = null!;
        [Required]

        [StringLength(50)]
        public string phone1 { get; set; } = null!;

        [StringLength(50)]
        public string? phone2 { get; set; }
        [Required]

        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        [Required]

        public int religionId { get; set; }
        public bool isAvtive { get; set; }


    }
}
