using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Interface
{
    public interface IJobRep
    {
        IEnumerable<job> GetAll();
        job GetById(int id);
        void create(job  department);
        void edit(job department);
        void delete(job department);
    }
}
