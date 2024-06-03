using Microsoft.AspNetCore.Mvc;

namespace Web_project.Controllers
{
    public class ContactController : Controller
    {
        [Route("contact")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
