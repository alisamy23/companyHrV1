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
    public class EmployeeRep:IEmployeeRep
    {
        private readonly CompanyContext context;

        public EmployeeRep(CompanyContext context)
        {

            this.context = context;
        }
        public void create(employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            context.SaveChanges();
        }

        public void delete(employee employee)
        {
            context.employees.Remove(employee);
            context.SaveChanges();
        }

        public void edit(employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();



        }

        public IEnumerable<CustomEmployeeVM> GetAll()
        {
            IQueryable<CustomEmployeeVM> data = getCustomEmployeeV();
            return data;
        }

        private IQueryable<CustomEmployeeVM> getCustomEmployeeV()
        {
                return context.employees.Include("deprtment").Include("gender").Include("religion").Select(o => new CustomEmployeeVM
                {
                    id = o.id,
                    nationalId = o.nationalId,
                    employeeName = o.employeeName,
                    endDate = o.endDate,
                    startDate = o.startDate,
                    birthdate = o.birthdate,
                    deprtmentName = o.deprtment.Name,
                    religionName = o.religion.religionName,
                    phone1 = o.phone1
                    ,
                    phone2 = o.phone2,
                    address = o.address,
                    genderName = o.gender.genderName,
                    isAvtive = o.isAvtive,

                });
        }

        public employee GetById(int id)
        {
            var data = context.employees.Include("deprtment").Include("gender").Include("religion").Where(o => o.id == id).FirstOrDefault();

            return data;



        }
    }
}
