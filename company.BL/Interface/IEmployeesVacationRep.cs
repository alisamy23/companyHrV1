using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IEmployeesVacationRep
    {
        IEnumerable<CustomEmployeesVacationVM> GetAll();
        employeesVacation GetById(int id);
        void create(employeesVacation employeesBonu);
        void edit(employeesVacation employeesBonu);
        void delete(employeesVacation employeesBonu);
    }
}
