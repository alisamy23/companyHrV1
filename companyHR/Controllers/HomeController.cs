using Microsoft.AspNetCore.Mvc;

namespace companyHR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
