using Microsoft.AspNetCore.Mvc;
using Web_project01.Models;

namespace Web_project01.Controllers
{
    public class ShopController : Controller
    {

        //public IActionResult Index()
        //{
        //    ProductRepository pr_repo = new ProductRepository();
        //    List<Models.ProductInfo> products = pr_repo.GetData();
        //    return View(products);
        //}
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebProject_DB;Integrated Security=True;";
        [Route("shop")]
        public IActionResult Index()
        {
            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
            List<ProductInfo> products = pr.GetAll();
            return View(products);
        }



    }
}
