using Microsoft.AspNetCore.Mvc;

namespace Web_project.Controllers
{
    public class LoginController : Controller
    {
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
