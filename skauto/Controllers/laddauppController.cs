using Microsoft.AspNetCore.Mvc;
using skauto.Models;

namespace skauto.Controllers
{
    public class laddauppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SparaNyBil(bilinfo bi)
        {
            bilinfo.Sparabil(bi);

            return RedirectToAction("Index", "Home"); 
        }
    }
}
