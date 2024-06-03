using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Web_project.Controllers
{
    public class AboutController : Controller
    {
        [Authorize(Policy = "ITDepartmentAccess")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
