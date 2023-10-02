using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class EmployeeBonusController : Controller
    {
        private readonly IEmployeeBounsRep employeeBounsRep;
        private readonly IMapper _mapper;
        public EmployeeBonusController(IEmployeeBounsRep _employeeBounsRep, IMapper mapper)
        {

            this.employeeBounsRep = _employeeBounsRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = employeeBounsRep.GetAll();
            var model = _mapper.Map<IEnumerable<CustomEmployeeBonusVm>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeBounsVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<employeesBonu>(model);
                    employeeBounsRep.create(data);

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
            var data = employeeBounsRep.GetById(id);
            var model = _mapper.Map<EmployeeBounsVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = employeeBounsRep.GetById(id);
            var model = _mapper.Map<EmployeeBounsVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult edit(EmployeeBounsVM model)
        {
            try
            {
                return editEmployeeBouns(model);
            }
            catch
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = employeeBounsRep.GetById(id);
            var model = _mapper.Map<EmployeeBounsVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(EmployeeBounsVM model)
        {

            try
            {
                var data = _mapper.Map<employeesBonu>(model);
                employeeBounsRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }




        private IActionResult editEmployeeBouns(EmployeeBounsVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _mapper.Map<employeesBonu>(model);
                employeeBounsRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
