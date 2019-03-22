using Microsoft.AspNetCore.Mvc;

namespace BlackJack.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}