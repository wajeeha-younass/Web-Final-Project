using Microsoft.AspNetCore.Mvc;
using Web_project01.Models;
namespace Web_project01.Controllers
{
    public class AdminController : Controller
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebProject_DB;Integrated Security=True;";


        [Route("/admin")]
        public IActionResult Index()
        {
            IRepository<ProductInfo> repo = new GenericRepository<ProductInfo>(connectionString);
            
            return View(repo.GetAll());
        }

        //[Route("/admin/addDress")]
        //public IActionResult addDress()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult addNewDress(Models.ProductInfo p)
        //{
        //    ProductRepository repo = new ProductRepository();
        //    repo.addItemInDB(p);
        //    return RedirectToAction("Index", "Shop");
        //}

        [Route("/admin/addDress")]
        public ViewResult addDress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addNewDress(ProductInfo p)
        {

            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
            pr.AddEntity(p);

            return RedirectToAction("Index","admin");
        } 


        [Route("/admin/deleteDress")]


     
        public ViewResult deleteDress()
        {
            return View();
        }
        [HttpPost]
        [Route("/admin/deleteDresses/{id}")]
        public IActionResult deleteDresses(int id)
        {
            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
            pr.DeleteById(id);

            return RedirectToAction("Index","admin");
        }

        //public IActionResult deleteDress()
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult deleteDresses(int ID)
        //{
        //    ProductRepository repo = new ProductRepository();
        //    //Console.WriteLine("Id" + ID);
        //    repo.deleteInDB(ID);
        //    return RedirectToAction("Index", "Shop");
        //}
        [Route("/admin/update")]
        //public IActionResult update()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult updateDress(Models.ProductInfo p)
        //{
        //    ProductRepository repo = new ProductRepository();
        //    repo.updateInDB(p);
        //    return RedirectToAction("Index", "Shop");
        //}

        [Route("/admin/update/{id}")]
        public ViewResult update(int id)
        {
            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
            return View(pr.FindById(id));
        }
        [HttpPost]
        public IActionResult updateDress(ProductInfo p)
        {


            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
            pr.UpdateById(p);

            return RedirectToAction("Index","admin");
        }

    }
}
