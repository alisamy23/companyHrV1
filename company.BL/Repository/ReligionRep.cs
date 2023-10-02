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
    public class ReligionRep:IReligionRep
    {
        private readonly CompanyContext context;

        public ReligionRep(CompanyContext context)
        {
            this.context = context;
        }
        public IEnumerable<religion> GetAll()
        {
            var data = context.religions;
            return data;
        }

    }
}
