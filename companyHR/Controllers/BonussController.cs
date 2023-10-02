using AutoMapper;
using company.BL.Interface;
using company.BL.Model;
using company.DAL.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class BonussController : Controller
    {
        private readonly IBonusRep bonusRep;
        private readonly IMapper _mapper;
        public BonussController(IBonusRep _bonusRep, IMapper mapper)
        {

            this.bonusRep = _bonusRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = bonusRep.GetAll();
            var model = _mapper.Map<IEnumerable<BonusVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(BonusVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<bonuss>(model);
                    bonusRep.create(data);

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
            var data = bonusRep.GetById(id);
            var model = _mapper.Map<BonusVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = bonusRep.GetById(id);
            var model = _mapper.Map<BonusVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult edit(BonusVM model)
        {
            try
            {
                return editBonus(model);
            }
            catch
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = bonusRep.GetById(id);
            var model = _mapper.Map<BonusVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(BonusVM model)
        {

            try
            {
                var data = _mapper.Map<bonuss>(model);
                bonusRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }




        private IActionResult editBonus(BonusVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _mapper.Map<bonuss>(model);
                bonusRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
