using Microsoft.AspNetCore.Mvc;
using skauto.Models;

namespace skauto.Controllers
{
    public class buycontroller : Controller
    {
        public IActionResult Index(int Id)
        {
            

           bilinfo bi  = bilinfo.GetCarsByID(Id);
           
            return View(bi);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
