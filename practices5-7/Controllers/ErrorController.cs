using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace practices5_7.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
