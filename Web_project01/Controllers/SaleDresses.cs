using Microsoft.AspNetCore.Mvc;

namespace Web_project.Controllers
{
    public class SaleDresses : Controller
    {
        [Route("SaleDress")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
