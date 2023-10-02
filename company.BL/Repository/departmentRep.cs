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
    public class departmentRep:IDepartmentRep
    {
    private readonly  CompanyContext context;

        public departmentRep(CompanyContext context)
        {
            this.context = context;
        }
        public void create(Department department)
        {
            Department department1 = new Department();
            department1.Id = department.Id;
            department1.Name = department.Name;
            context.Departments.Add(department1);
            context.SaveChanges();
        }

        public void delete(Department department)
        {
           
                context.Departments.Remove(department);
                context.SaveChanges();

            
        }

        public void edit(Department department)
        {
            context.Entry(department). State=EntityState.Modified;
            context.SaveChanges();
            


        }

        public IEnumerable<Department> GetAll()
        {
            var data = context.Departments;
            return data; 
        }

        public Department GetById(int id)
        {
            var data = context.Departments.Where(o => o.Id == id).FirstOrDefault();

            return data;



        }
    }
}
