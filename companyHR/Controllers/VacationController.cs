using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class VacationController : Controller
    {
        private readonly IVacationRep vacationRep;
        private readonly IMapper _mapper;
        public VacationController(IVacationRep _vacationRep, IMapper mapper)
        {

            this.vacationRep = _vacationRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = vacationRep.GetAll();
            var model = _mapper.Map<IEnumerable<VacationVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(VacationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<vacation>(model);
                    vacationRep.create(data);

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
            var data = vacationRep.GetById(id);
            var model = _mapper.Map<VacationVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = vacationRep.GetById(id);
            var model = _mapper.Map<VacationVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult edit(VacationVM model)
        {
            try
            {
                return editVacation(model);
            }
            catch
            {
                return View(model);
            }

        }



        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = vacationRep.GetById(id);
            var model = _mapper.Map<VacationVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(VacationVM model)
        {

            try
            {
                var data = _mapper.Map<vacation>(model);
                vacationRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }




        private IActionResult editVacation(VacationVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _mapper.Map<vacation>(model);
                vacationRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
