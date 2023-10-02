using company.BL.Interface;
using company.DAL.Entity;
using company.DAL.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Repository
{
    public class GenderRep:IGenderRep
    {
        private readonly CompanyContext context;

        public GenderRep(CompanyContext context)
        {
            this.context = context;
        }
        public IEnumerable<gender> GetAll()
        {
            var data = context.genders;
            return data;
        }
    }
}
