using AutoMapper;
using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile() {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();
          
            CreateMap<job, jobVM>();
            CreateMap<jobVM, job>();           
           
            CreateMap<bonuss, BonusVM>();
            CreateMap<BonusVM,bonuss >();
          
            CreateMap<vacation, VacationVM>();
            CreateMap<VacationVM, vacation>();
          
            CreateMap<religion, ReligionVM>();
            CreateMap<ReligionVM, religion>();
          
            CreateMap<gender, GenderVM>();
            CreateMap<GenderVM, gender>();
          
            CreateMap<employee, EmployeeVM>();
            CreateMap<EmployeeVM,employee>();

            CreateMap<employeesBonu, EmployeeBounsVM>();
            CreateMap<EmployeeBounsVM, employeesBonu>();


            CreateMap<employeesVacation, EmployeesVacationVM>();
            CreateMap<EmployeesVacationVM, employeesVacation>();




        }
    }
}
