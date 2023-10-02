using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IEmployeeBounsRep
    {
        IEnumerable<CustomEmployeeBonusVm> GetAll();
        employeesBonu GetById(int id);
        void create(employeesBonu employeesBonu);
        void edit(employeesBonu employeesBonu);
        void delete(employeesBonu employeesBonu);
    }
}
