using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class IsteklerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
