using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practices5_7.Data;
using practices5_7.Models;

namespace practices5_7.Controllers
{
        public class PartyController : Controller
        {
        private readonly peopleContext db;
        public PartyController(peopleContext context)
        {
            db = context;
        }
        // GET: Party
        public ActionResult Index()
            {
                return View();
            }

            public ActionResult Display()
            {
                return View(db.Parties.ToList());
            }

            public ActionResult Form()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Form(Party model)
            {
                if (ModelState.IsValid)
                {
                    Party party = null;
                    
                        party = db.Parties.FirstOrDefault(u => u.Number == model.Number);
                    
                    if (party == null)
                    {
                        

                            db.Parties.Add(new Party { Name = model.Name, Status = model.Status, Number = model.Number, Text = model.Text });

                            db.SaveChanges();

                            party = db.Parties.Where(u => u.Name == model.Name && u.Number == model.Number).FirstOrDefault();
                        

                        if (party != null)
                        {
                            
                            return RedirectToAction("ThankYou", "Party");
                        }
                    }
                    if (party != null)
                    {
                        db.Parties.Where(u => u.Number == model.Number).FirstOrDefault().Status = model.Status;
                        db.Parties.Where(u => u.Number == model.Number).FirstOrDefault().Text = model.Text;
                        db.SaveChanges();
                        if (party != null)
                        {
                            return RedirectToAction("ThankYou", "Party");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вы уже отвечали");
                    }
                }
                return View(model);
            }

            public ActionResult ThankYou()
            {
                return View();
            }
        }
    }
