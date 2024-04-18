using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class OgrencilerController : Controller
    {
        public readonly UygulamaDbContext _uygulamaDbContext;
        public OgrencilerController(UygulamaDbContext context)
        {
            _uygulamaDbContext = context;
        }
        public IActionResult Index()
        {
            List<Ogrenciler> objOgrencilerList = _uygulamaDbContext.OgrencilerTbl.ToList();
            return View(objOgrencilerList);
        }

        public IActionResult OgrenciEKle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OgrenciEKle(Ogrenciler ogrenciler)
        {
            if(ModelState.IsValid)
            {
                _uygulamaDbContext.OgrencilerTbl.Add(ogrenciler);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
