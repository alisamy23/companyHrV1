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
    public class EmployeeBounsRep:IEmployeeBounsRep
    {
        private readonly CompanyContext context;

        public EmployeeBounsRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(employeesBonu employeesBonu)
        {
            context.Entry(employeesBonu).State = EntityState.Added;
            context.SaveChanges();
        }

        public void delete(employeesBonu employeesBonu)
        {
            context.employeesBonus.Remove(employeesBonu);
            context.SaveChanges();
        }

        public void edit(employeesBonu employeesBonu)
        {
            context.Entry(employeesBonu).State = EntityState.Modified;
            context.SaveChanges();
        }
        
        public IEnumerable<CustomEmployeeBonusVm> GetAll()
        {

            var data = context.employeesBonus.Include("employee").Include("bonus").Select(o => new CustomEmployeeBonusVm
            {
             id=   o.id,
                bonusName=   o.bonus.bonusName,
                employeeName=  o.employee.employeeName,
                Bonusflag=  o.bonus.Bonusflag,
                bonusValue= o.bonus.bonusValue,
                bonusDate=  o.date,
            });
            return data;
        }

        public employeesBonu GetById(int id)
        {
            var data = context.employeesBonus.Where(o => o.id == id).FirstOrDefault();
            return data;
        }
    }
}
