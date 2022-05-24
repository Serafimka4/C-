using Microsoft.AspNetCore.Mvc;
using practices5_7.Models;

namespace practices5_7.Controllers
{
    public class CulculatorController : Controller
    {  
          public ActionResult Index(Culculator model)
            {
                double x;
                double y;
                double c = 0;
                if (double.TryParse(model.X, out x) && double.TryParse(model.Y, out y))
                {
                    switch (model.Op)
                    {
                        case "Plus":
                            c = x + y;
                            ViewBag.Result = c;
                            break;
                        case "Minus":
                            c = x - y;
                            ViewBag.Result = c;
                            break;
                        case "Multiply":
                            c = x * y;
                            ViewBag.Result = c;
                            break;
                        case "Division":
                            if (y == 0)
                            {
                                ViewBag.Result = "Не определен";
                                break;
                            }
                            else
                            {
                                c = x / y;
                                ViewBag.Result = c;
                                break;
                            }
                    }
                }
                else
                {
                    ViewBag.Result = "NaN";
                }

                return View();
            }
        }
  }
