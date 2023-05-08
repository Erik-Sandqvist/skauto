using Microsoft.AspNetCore.Mvc;
using skauto.Models;

namespace skauto.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string mailadress, string password, string namn)
        {
            bool lyckad = skuser.registerNyUser(mailadress, password, namn);
            return RedirectToAction("Index", "laddaupp");
        }

            public IActionResult Login(string mailadress, string password)
        {
            skuser anton  = skuser.GetEmployeeByMail(mailadress);

            if (anton.password == password)
            {
                return RedirectToAction("Index", "laddaupp");
            }
            else
            {
                ViewBag.ErrorMSG = "Fel ...";
                return View("Index"); 
            }
        }
    }
}
