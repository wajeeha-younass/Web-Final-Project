using Microsoft.AspNetCore.Mvc;

namespace Web_project01.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public UploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("upload")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> submittedFile)
        {
            string wwwFolder = _env.WebRootPath;
            string path = Path.Combine(wwwFolder, "UploadedFiles");

            // Ensure the directory exists, create it if not
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in submittedFile)
            {
                string fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);

                using (var stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            return RedirectToAction("Index");
        }

    }
}