using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class OgrencilerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
