//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using Web_project01.Models;

//namespace Web_project01.Controllers
//{
//    public class TaskController : Controller
//    {
//        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebProject_DB;Integrated Security=True;";

//        public IActionResult AddProduct()
//        {
//            var product = new ProductInfo
//            {
//                ImageUrl = "chips",
//                Name = "abc",
//                Price = 2,
//                ProductId = 50
//            };

//            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
//            pr.Add(product);

//            return RedirectToAction(nameof(ViewAllProducts));
//        }


//        [Route("shop")]
//        public IActionResult ViewAllProducts()
//        {
//            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
//            IEnumerable<ProductInfo> products = pr.GetAll();
//            return View("Index","Shop");
//        }

//        public IActionResult DeleteProduct()
//        {
//            int id = 1;
//            IRepository<ProductInfo> pr = new GenericRepository<ProductInfo>(connectionString);
//            pr.DeleteById(id);
//            return RedirectToAction(nameof(ViewAllProducts));
//        }
//    }
//}

    