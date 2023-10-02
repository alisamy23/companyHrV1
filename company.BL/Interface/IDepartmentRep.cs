using company.BL.Model;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IDepartmentRep
        {
            IEnumerable<Department> GetAll();
             Department GetById(int id);
            void create (Department department);
            void edit(Department department);
            void delete(Department department);

    }
}
