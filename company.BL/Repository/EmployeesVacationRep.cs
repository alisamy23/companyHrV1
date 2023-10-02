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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace company.BL.Repository
{
    public class EmployeesVacationRep:IEmployeesVacationRep
    {
        private readonly CompanyContext context;

        public EmployeesVacationRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(employeesVacation employeesVacation)
        {
            context.Entry(employeesVacation).State = EntityState.Added;
            context.SaveChanges();
        }

        public void delete(employeesVacation employeesVacation)
        {
            context.employeesVacations.Remove(employeesVacation);
            context.SaveChanges();
        }

        public void edit(employeesVacation employeesVacation)
        {
            context.Entry(employeesVacation).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<CustomEmployeesVacationVM> GetAll()
        {

            var data = context.employeesVacations.Include("employee").Include("vacation").Select(o => new CustomEmployeesVacationVM
            {
                id = o.id,
                vacationName = o.vacation.vacationName,
                vacationCost = o.vacation.vacationCost,
                employeeName = o.employee.employeeName,
                fromDate = o.fromDate,
                toDate=  o.toDate
            });
            return data;
        }

        public employeesVacation GetById(int id)
        {
            var data = context.employeesVacations.Where(o => o.id == id).FirstOrDefault();
            return data;
        }
    }
}
