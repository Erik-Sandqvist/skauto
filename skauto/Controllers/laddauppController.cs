using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using skauto.Models;

namespace skauto.Controllers
{
    public class laddauppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


       


        public IActionResult SparaNyBil(bilinfoPlusBild pi)
        {
            try
            {


                Guid g = Guid.NewGuid();
                string fileName = g.ToString() + ".jpg";
                pi.FilNamn = fileName;                

                string uploadpath = Directory.GetCurrentDirectory() + "\\upload\\" + fileName;

                var stream = new FileStream(uploadpath, FileMode.Create);

                pi.produktImage.CopyToAsync(stream);

                ViewBag.Message = "File uploaded successfully.";
                bilinfo.Sparabil(pi);

            }

            catch

            {

                ViewBag.Message = "Error while uploading the files.";

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
