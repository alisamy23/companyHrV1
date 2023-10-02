using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IVacationRep
    {
        IEnumerable<vacation> GetAll();
        vacation GetById(int id);
        void create(vacation department);
        void edit(vacation department);
        void delete(vacation department);
    }
}
