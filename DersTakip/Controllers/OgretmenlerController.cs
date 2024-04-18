using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        public IActionResult OgretmenEkle(Ogretmenler ogretmenler)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.OgretmenlerTbl.Add(ogretmenler);
                _uygulamaDbContext.SaveChanges();   // YApmazsan veritabanına eklenmez. => SaveChanges();
                return RedirectToAction("Index");    // "Ogretmenler" controllerını çağırıyoruz farklı bi cont. çağırcaksak kesin yazmak zorunda
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            Ogretmenler? ogretmenlerVt = _uygulamaDbContext.OgretmenlerTbl.Find(id);
            if(ogretmenlerVt == null)
            {
                return NotFound();
            }
            return View(ogretmenlerVt);
        }

        [HttpPost]
        public IActionResult Guncelle(Ogretmenler ogretmenler)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.OgretmenlerTbl.Update(ogretmenler);
                _uygulamaDbContext.SaveChanges();   // YApmazsan veritabanına eklenmez. => SaveChanges();
                return RedirectToAction("Index");    // "Ogretmenler" controllerını çağırıyoruz farklı bi cont. çağırcaksak kesin yazmak zorunda
            }
            return View();
        }

        // GET ACTION
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Ogretmenler? ogretmenlerVt = _uygulamaDbContext.OgretmenlerTbl.Find(id);
            if (ogretmenlerVt == null)
            {
                return NotFound();
            }
            return View(ogretmenlerVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Ogretmenler? ogretmenler = _uygulamaDbContext.OgretmenlerTbl.Find(id);
            if(ogretmenler == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.OgretmenlerTbl.Remove(ogretmenler);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index", "Ogretmenler");
        }


    }
}
