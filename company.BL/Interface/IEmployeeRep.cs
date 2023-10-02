using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IEmployeeRep
    {
        IEnumerable<CustomEmployeeVM> GetAll();
        employee GetById(int id);
        void create(employee employee);
        void edit(employee employee);
        void delete(employee employee);
    }
}
