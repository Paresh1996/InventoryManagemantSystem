using InventoryManagemantSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagemantSystem.Controllers
{
    public class PurchaseController : Controller
    {
       
        // GET: PurchaseController
        public ActionResult Index()
        {
            Purchase pro = new Purchase();
            List<Purchase> prolst = pro.GetPurchase();
            return View(prolst);
        }

        // GET: PurchaseController/Details/5
        public ActionResult Details(int id)
        {
            Purchase pro = new Purchase();
            Purchase obj = pro.GetSinglePurchase(id);
            return View(obj);
        }

        // GET: PurchaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Purchase obj,IFormCollection collection)
        {
            try
            {
                Purchase pro = new Purchase();
                pro.insert(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Edit/5
        public ActionResult Edit(int id)
        {
            Purchase pro = new Purchase();
            Purchase obj = pro.GetSinglePurchase(id);
            return View(obj);
        }

        // POST: PurchaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Purchase obj)
        {
            try
            {
                Purchase pro = new Purchase();
                pro.update(obj.Id,obj.PurchaseProd,obj.PurchaseQnty,obj.PurchaseDate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseController/Delete/5
        public ActionResult Delete(int id)
        {
            Purchase pro = new Purchase();
            Purchase obj = pro.GetSinglePurchase(id);
            return View(obj);
        }

        // POST: PurchaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Purchase pro = new Purchase();
                pro.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            Product pro = new Product();
            List<Product> list = pro.GetProduct();
            List<String?> ProName = new List<string?>();
            foreach (var item in list)
            {
                ProName.Add(item.ProductName);
            }
            ViewBag.ProductName = new SelectList(ProName);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase obj)
        {
            Purchase pro = new Purchase();
            Product pro1 = new Product();
            pro1.update(obj);
            pro.insert(obj);
            return RedirectToAction("Index");
        }
    }
}
