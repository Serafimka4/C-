using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.DAL;
using WebShop.Models;
using System.Diagnostics;

namespace WebShop.Controllers
{
    public class CustomersController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await db.Customers.ToListAsync());
        }

        // GET: Customers/Create
        public ActionResult Basket()
        {
            return View();
        }

        // POST: Customers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Basket([Bind(Include = "CustomerID,FIO,PhoneNumber,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                
                
                foreach (var ok in (List<Ok>)Session["basket"])
                {
                    db.OkOperation.FirstOrDefault(g => g.OkId == ok.OkId).Amount -= ok.Amount;
                    Purchase purchase = new Purchase
                    {
                        OkId = ok.OkId,
                        CustomerID = customer.CustomerID,
                        AmountGood = ok.Amount,
                        //Good = good,
                        //Customer = customer
                    };
                    db.Purchases.Add(purchase);
                    if (customer.Purchases == null) customer.Purchases = new List<Purchase> { };
                    customer.Purchases.Add(purchase);
                    ok.Purchases.Add(purchase);
                }
                Session["basket"] = new List<Ok> { };

                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return RedirectToAction("../Goods/Index");
            }

            

            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ViewResult Cust()
        {
            return View(db.Customers);
        }


    }
}
