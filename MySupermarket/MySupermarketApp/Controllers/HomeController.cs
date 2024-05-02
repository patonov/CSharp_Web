using Microsoft.AspNetCore.Mvc;

namespace MySupermarketApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
