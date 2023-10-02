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
    public class JobRep : IJobRep
    {
        private readonly CompanyContext context;

        public JobRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(job job)
        {
            context.Entry(job).State = EntityState.Added;

            context.SaveChanges();
        }

        public void delete(job job)
        {

            context.jobs.Remove(job);
            context.SaveChanges();


        }

        public void edit(job job )
        {
            context.Entry(job).State = EntityState.Modified;
            context.SaveChanges();



        }

        public IEnumerable<job> GetAll()
        {
            var data = context.jobs;
            return data;
        }

        public job GetById(int id)
        {
            var data = context.jobs.Where(o => o.id == id).FirstOrDefault();

            return data;



        }
    }
}
