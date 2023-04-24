using Microsoft.AspNetCore.Mvc;

namespace skauto.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registrerar()
        {
            return View();
        }

        public IActionResult Login(string mailadress, string password)
        {

            return RedirectToAction("Index", "laddaupp"); 
        }
    }
}
