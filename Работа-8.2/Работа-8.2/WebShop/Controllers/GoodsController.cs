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
            return View(db.Goods.ToList());
        }



        // GET: Goods/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = await db.Goods.FindAsync(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
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
        public async Task<ActionResult> Create([Bind(Include = "GoodID,Name,Amount,Price,Description")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(good);
                await db.SaveChangesAsync();
                return RedirectToAction("AdminTable");
            }

            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = await db.Goods.FindAsync(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: Goods/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GoodID,Name,Amount,Price,Description")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Entry(good).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AdminTable");
            }
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = await db.Goods.FindAsync(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Good good = await db.Goods.FindAsync(id);
            db.Goods.Remove(good);
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
                    return View("AdminTable", db.Goods);
                }
            };
            return View();
        }

        public ViewResult AdminTable()
        { 
            return View(db.Goods);
        }

        public ViewResult GetBasketPage()
        {
            return View("Basket", Session["basket"]);
        }


        public ActionResult Test1(int? amount)
        {
            if (amount == null)
            {
                return View("Index", db.Goods.ToList());
            }

            int id = Convert.ToInt32(Request.Form["id"]);


            Debug.WriteLine(id + "  amount: " + amount);


            if (id == null || amount == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good goodDb = db.Goods.FirstOrDefault(p => p.GoodID == id);

            if (amount <= 0 )
            {
                return View("Index", db.Goods.ToList());
            }
            else if (amount > goodDb.Amount) amount = goodDb.Amount;

            AddToBasket(amount , id);

            return RedirectToAction("Index");
        }

        public void AddToBasket(int? amount, int? id)
        {

            foreach (var gd in (List<Good>)Session["basket"])
            {
                if (id == gd.GoodID )
                {
                    amount = gd.Amount + amount;
                    if (db.Goods.FirstOrDefault(p => p.GoodID == id).Amount <= gd.Amount)
                    {
                        amount = db.Goods.FirstOrDefault(p => p.GoodID == id).Amount;
                    }
                    gd.Amount = (int)amount;
                    return;
                }
            }
            Good good = db.Goods.FirstOrDefault(p => p.GoodID == id);

            Debug.WriteLine(good.GoodID + good.Name + good.Price);

            if (good != null)
            {
                Good good1 = new Good
                {
                    Name = good.Name,
                    Price = good.Price,
                    Amount = (int)amount,
                    Description = good.Description,
                    GoodID = good.GoodID,
                    Purchases = good.Purchases
                };

                List<Good> lst = (List<Good>)Session["basket"];
                if (lst == null)
                {
                    lst = new List<Good> { good1 };
                    
                }
                else lst.Add(good1);
                
                Session["basket"] = lst;
                ViewBag.basket = lst;

                Debug.WriteLine(((List<Good>)ViewBag.basket)[0].GoodID);
            }
        }



        public ViewResult Test()
        {
            return View();
        }


    }
}
