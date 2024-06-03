using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Web_project.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize("BussinessHoursOnly")]
      
        public IActionResult Index()
        {
            string data;
            if (!HttpContext.Request.Cookies.ContainsKey("first_visit"))
            {
                CookieOptions options = new CookieOptions
                {

                    Expires = DateTime.Now.AddDays(1)
                };
                HttpContext.Response.Cookies.Append("first_visit",DateTime.Now.ToString(),options);
                data = "You are visiting for the first time";
            }
            else {
                data = HttpContext.Request.Cookies["first_visit"];
                data = "Welcome Back,You visited first time at : " + data;
            
            }
            return View((object)data);
        }

    }
}
