using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class EmployeesVacationController : Controller
    {
        private readonly IEmployeesVacationRep employeesVacationRep;
        private readonly IMapper _mapper;
        public EmployeesVacationController(IEmployeesVacationRep _EmployeesVacationVM, IMapper mapper)
        {

            this.employeesVacationRep = _EmployeesVacationVM;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = employeesVacationRep.GetAll();
            var model = _mapper.Map<IEnumerable<CustomEmployeesVacationVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeesVacationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<employeesVacation>(model);
                    employeesVacationRep.create(data);

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
            var data = employeesVacationRep.GetById(id);
            var model = _mapper.Map<EmployeesVacationVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = employeesVacationRep.GetById(id);
            var model = _mapper.Map<EmployeesVacationVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult edit(EmployeesVacationVM model)
        {
            try
            {
                return editEmployeesVacation(model);
            }
            catch
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = employeesVacationRep.GetById(id);
            var model = _mapper.Map<EmployeesVacationVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(EmployeesVacationVM model)
        {

            try
            {
                var data = _mapper.Map<employeesVacation>(model);
                employeesVacationRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }




        private IActionResult editEmployeesVacation(EmployeesVacationVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _mapper.Map<employeesVacation>(model);
                employeesVacationRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
