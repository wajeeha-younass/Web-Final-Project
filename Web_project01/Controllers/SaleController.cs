using Microsoft.AspNetCore.Mvc;

namespace Web_project.Controllers
{
    public class SaleController : Controller
    {
        [Route("Sale")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
