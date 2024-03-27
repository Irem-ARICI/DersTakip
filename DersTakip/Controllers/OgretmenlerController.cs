using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class OgretmenlerController : Controller
    {
        // Dependency injection

        private readonly UygulamaDbContext _uygulamaDbContext;
        public OgretmenlerController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            String ornek = "merhaba";
            ViewBag.ornek = ornek;

            List<Ogretmenler> objOgretmenlerList = _uygulamaDbContext.OgretmenlerTbl.ToList();
            return View(objOgretmenlerList);
        }

        public IActionResult OgretmenEkle()
        {
            return View();
        }
    }
}
