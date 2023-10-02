using company.BL.Interface;
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
    public class VacationRep:IVacationRep
    {
        private readonly CompanyContext context;

        public VacationRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(vacation vacation)
        {
            context.Entry(vacation).State = EntityState.Added;

            context.SaveChanges();
        }

        public void delete(vacation vacation)
        {

            context.vacations.Remove(vacation);
            context.SaveChanges();


        }

        public void edit(vacation vacation)
        {
            context.Entry(vacation).State = EntityState.Modified;
            context.SaveChanges();



        }

        public IEnumerable<vacation> GetAll()
        {
            var data = context.vacations;
            return data;
        }

        public vacation GetById(int id)
        {
            var data = context.vacations.Where(o => o.id == id).FirstOrDefault();

            return data;



        }
    }
}
