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

namespace WebShop.Controllers
{
    public class BasketController : Controller
    {

        private ShopContext db = new ShopContext();

        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }
    }
}