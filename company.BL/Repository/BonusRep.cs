using company.BL.Interface;
using company.BL.Model;
using company.DAL.Entity;
using company.DAL.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace company.BL.Repository
{
    public class BonusRep:IBonusRep
    {
        private readonly CompanyContext context;

        public BonusRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(bonuss bonuss)
        {
            context.Entry(bonuss).State = EntityState.Added;
            context.SaveChanges();
        }

        public void delete(bonuss bonuss)
        {
            context.bonusses.Remove(bonuss);
            context.SaveChanges();
        }

        public void edit(bonuss bonuss)
        {
            context.Entry(bonuss).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<bonuss> GetAll()
        {
            var data = context.bonusses;
            return data;
        }

        public bonuss GetById(int id)
        {
            var data = context.bonusses.Where(o => o.id == id).FirstOrDefault();
            return data;
        }
    }
}
