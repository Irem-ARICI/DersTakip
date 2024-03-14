using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class OgretmenlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
