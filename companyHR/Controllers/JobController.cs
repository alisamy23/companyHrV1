using Microsoft.AspNetCore.Mvc;
using company.BL.Interface;
using AutoMapper;
using company.BL.Model;
using company.DAL.Repository.Models;

namespace companyHR.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRep jobRep;
        private readonly IMapper _mapper;
        public JobController(IJobRep _jobRep, IMapper mapper)
        {

            this.jobRep = _jobRep;
            this._mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = jobRep.GetAll();
            var model = _mapper.Map<IEnumerable<jobVM>>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(jobVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = _mapper.Map<job>(model);
                    jobRep.create(data);

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
            var data = jobRep.GetById(id);
            var model = _mapper.Map<jobVM>(data);
            return View(model);
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            var data = jobRep.GetById(id);
            var model = _mapper.Map<jobVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult edit(jobVM model)
        {
            try
            {
                return editjob(model);
            }
            catch
            {
                return View(model);
            }

        }



        [HttpGet]
        public IActionResult delete(int id)
        {
            var data = jobRep.GetById(id);
            var model = _mapper.Map<jobVM>(data);

            return View(model);
        }
        [HttpPost]
        public IActionResult delete(jobVM model)
        {

            try
            {
                var data = _mapper.Map<job>(model);
                jobRep.delete(data);

                return RedirectToAction("Index");


            }
            catch
            {
                return View();

            }
        }


        private IActionResult editjob(jobVM model)
        {
            if (ModelState.IsValid)
            {

                var data = _mapper.Map<job>(model);
                jobRep.edit(data);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}
