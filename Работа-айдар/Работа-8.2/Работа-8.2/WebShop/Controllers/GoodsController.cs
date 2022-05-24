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
    public class GoodsController : Controller
    {
        private ShopContext db = new ShopContext();


        public ViewResult Index()
        {
            return View(db.OkOperation.ToList());
        }



        // GET: Goods/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ok ok = await db.OkOperation.FindAsync(id);
            if (ok == null)
            {
                return HttpNotFound();
            }
            return View(ok);
        }

        // GET: Goods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GoodID,Name,Amount,Price,Description")] Ok ok)
        {
            if (ModelState.IsValid)
            {
                db.OkOperation.Add(ok);
                await db.SaveChangesAsync();
                return RedirectToAction("AdminTable");
            }

            return View(ok);
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ok ok = await db.OkOperation.FindAsync(id);
            if (ok == null)
            {
                return HttpNotFound();
            }
            return View(ok);
        }

        // POST: Goods/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OkId,Name,Amount,Price,Description")] Ok ok)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ok).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AdminTable");
            }
            return View(ok);
        }

        // GET: Goods/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ok ok = await db.OkOperation.FindAsync(id);
            if (ok == null)
            {
                return HttpNotFound();
            }
            return View(ok);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ok ok = await db.OkOperation.FindAsync(id);
            db.OkOperation.Remove(ok);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminTable");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ViewResult Authorize()
        {
            return View();
        }
        
        [HttpPost]
        public ViewResult Authorize(Admin admin)
        {
            foreach (var adm in db.Admins.ToList<Admin>()) {
                if (adm.Login == admin.Login && adm.Password == admin.Password)
                {
                    return View("AdminTable", db.OkOperation);
                }
            };
            return View();
        }

        public ViewResult AdminTable()
        { 
            return View(db.OkOperation);
        }

        public ViewResult GetBasketPage()
        {
            return View("Basket", Session["basket"]);
        }


        public ActionResult Test1(int? amount)
        {
            if (amount == null)
            {
                return View("Index", db.OkOperation.ToList());
            }

            int id = Convert.ToInt32(Request.Form["id"]);


            Debug.WriteLine(id + "  amount: " + amount);


            if (id == null || amount == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ok okDb = db.OkOperation.FirstOrDefault(p => p.OkId == id);

            if (amount <= 0 )
            {
                return View("Index", db.OkOperation.ToList());
            }
            else if (amount > okDb.Amount) amount = okDb.Amount;

            AddToBasket(amount , id);

            return RedirectToAction("Index");
        }

        public void AddToBasket(int? amount, int? id)
        {

            foreach (var gd in (List<Ok>)Session["basket"])
            {
                if (id == gd.OkId )
                {
                    amount = gd.Amount + amount;
                    if (db.OkOperation.FirstOrDefault(p => p.OkId == id).Amount <= gd.Amount)
                    {
                        amount = db.OkOperation.FirstOrDefault(p => p.OkId == id).Amount;
                    }
                    gd.Amount = (int)amount;
                    return;
                }
            }
            Ok ok = db.OkOperation.FirstOrDefault(p => p.OkId == id);

            Debug.WriteLine(ok.OkId + ok.Name + ok.Price);

            if (ok != null)
            {
                Ok ok1 = new Ok
                {
                    Name = ok.Name,
                    Price = ok.Price,
                    Amount = (int)amount,
                    Description = ok.Description,
                    OkId = ok.OkId,
                    Purchases = ok.Purchases
                };

                List<Ok> lst = (List<Ok>)Session["basket"];
                if (lst == null)
                {
                    lst = new List<Ok> { ok1 };
                    
                }
                else lst.Add(ok1);
                
                Session["basket"] = lst;
                ViewBag.basket = lst;

                Debug.WriteLine(((List<Ok>)ViewBag.basket)[0].OkId);
            }
        }



        public ViewResult Test()
        {
            return View();
        }


    }
}
