using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRep employeeRep;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeeRep _employeeRep, IMapper mapper)
        {

            this.employeeRep = _employeeRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = employeeRep.GetAll();
            var model = _mapper.Map<IEnumerable<CustomEmployeeVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<employee>(model);
                    employeeRep.create(data);

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
            var data = employeeRep.GetById(id);
            var model = _mapper.Map<EmployeeVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = employeeRep.GetById(id);
            var model = _mapper.Map<EmployeeVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult edit(EmployeeVM model)
        {
            try
            {
                return editEmployee(model);
            }
            catch
            {
                return View(model);
            }

        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = employeeRep.GetById(id);
            var model = _mapper.Map<EmployeeVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(EmployeeVM model)
        {

            try
            {
                var data = _mapper.Map<employee>(model);
                employeeRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }
        private IActionResult editEmployee(EmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<employee>(model);
                employeeRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
