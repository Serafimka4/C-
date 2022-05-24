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
                
                
                foreach (var good in (List<Good>)Session["basket"])
                {
                    db.Goods.FirstOrDefault(g => g.GoodID == good.GoodID).Amount -= good.Amount;
                    Purchase purchase = new Purchase
                    {
                        GoodID = good.GoodID,
                        CustomerID = customer.CustomerID,
                        AmountGood = good.Amount,
                        //Good = good,
                        //Customer = customer
                    };
                    db.Purchases.Add(purchase);
                    if (customer.Purchases == null) customer.Purchases = new List<Purchase> { };
                    customer.Purchases.Add(purchase);
                    good.Purchases.Add(purchase);
                }
                Session["basket"] = new List<Good> { };

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
        /*
        public ViewResult Basket()
        {
            return View();
        }*/


        //DELETE IT
        public ViewResult Cust()
        {

            /*foreach(var purch in db.Customers.First(p => p.CustomerID == 1).Purchases)
            {
                Debug.WriteLine(purch.GoodID);
            }*/
            
            return View(db.Customers);
        }


    }
}
