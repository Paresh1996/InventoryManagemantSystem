using InventoryManagemantSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagemantSystem.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            Product pro = new Product();
            List<Product> prolst = pro.GetProduct();
            return View(prolst);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product pro = new Product();
            Product obj = pro.GetSingleProduct(id);
            return View(obj);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product obj,IFormCollection collection)
        {
            try
            {
                Product pro = new Product();
                pro.insert(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product pro = new Product();
            Product obj=pro.GetSingleProduct(id);
            return View(obj);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Product obj)
        {
            try
            {
                Product pro = new Product();
                pro.update(obj.Id,obj.ProductName,obj.ProductQnty);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product pro = new Product();
            Product obj = pro.GetSingleProduct(id);
            return View(obj);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Product pro = new Product();
                pro.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
