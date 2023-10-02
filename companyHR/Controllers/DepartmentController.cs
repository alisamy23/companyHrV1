using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.BL.Repository;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class DepartmentController : Controller
    {
      
        private readonly IDepartmentRep departmentRep;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentRep _departmentRep, IMapper mapper) { 
       
            this.departmentRep = _departmentRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data= departmentRep.GetAll();
            var model = _mapper.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create() 
        { 
        
          return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM  model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<Department>(model);
                    departmentRep.create(data);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }

            }
            catch
            {
                return View(model);

            }

        }
        [HttpGet]
        public IActionResult details(int id) 
        {
         var data= departmentRep.GetById(id);
            var model = _mapper.Map<DepartmentVM>(data);
          return View(model);
        }        
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = departmentRep.GetById(id);
            var model = _mapper.Map<DepartmentVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult edit(DepartmentVM model)
        {
            try
            {
                return editDepartment(model);
            }
            catch
            {
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult delete(int id) 
        {
            var data = departmentRep.GetById(id);
            var model = _mapper.Map<DepartmentVM>(data);

            return View(model);
        }    
        [HttpPost]
        public IActionResult delete(DepartmentVM model) 
        {

            try
            {
                var data = _mapper.Map<Department>(model);
                    departmentRep.delete(data);

                    return RedirectToAction("Index");
               

            }
            catch
            {
                return View();

            }
        }
        private IActionResult editDepartment(DepartmentVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Department>(model);
                departmentRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
