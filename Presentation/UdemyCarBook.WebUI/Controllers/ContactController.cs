using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
     

        public IActionResult Index()
        {
            return View();
        }
    }
}
