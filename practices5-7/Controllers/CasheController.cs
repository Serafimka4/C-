using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practices5_7.Data;
using System.Runtime.Caching;
using practices5_7.Models;

namespace practices5_7.Controllers
{
    public class CasheController : Controller
    {
        private readonly peopleContext context;
        public CasheController(peopleContext db)
        {
            context = db;
        }



        [HttpGet]
        public ActionResult Index()
        {
            List<PeopleModel> clients = MemoryCache.Default.Get("Clients") as List<PeopleModel>;
            if (clients == null)
            {
                clients = new List<PeopleModel>();
                foreach (PeopleModel c in context.PeopleModel)
                {
                    PeopleModel client = new PeopleModel();
                    client.Name = c.Name;
                    client.Awards = c.Awards;
                    clients.Add(client);
                }
                MemoryCache.Default.Add("Clients", clients, DateTimeOffset.Now.AddMinutes(1));
                ViewBag.Text = "Некешированные данные";
            }
            else
            {
                ViewBag.Text = "Данные из кеша";

            }
            return View(clients);
        }
    }
}
