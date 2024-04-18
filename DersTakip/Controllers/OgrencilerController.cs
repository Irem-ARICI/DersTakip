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



        public IActionResult Guncelle(int? Sinifi)  // TC yi yemedi ~OgretmenlerController->id 
        {
            if(Sinifi == null || Sinifi == 0)
            {
                return NotFound();
            }
            Ogrenciler? ogrencilerVt = _uygulamaDbContext.OgrencilerTbl.Find(Sinifi);
            if (ogrencilerVt == null)
            {
                return NotFound();
            }
            return View(ogrencilerVt);
        }

        [HttpPost]
        public IActionResult Guncelle(Ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                _uygulamaDbContext.OgrencilerTbl.Update(ogrenciler);
                _uygulamaDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }



        public IActionResult Sil(int? TC)  // TC yi yemedi ~OgretmenlerController->id 
        {
            if (TC == null || TC == 0)
            {
                return NotFound();
            }
            Ogrenciler? ogrencilerVt = _uygulamaDbContext.OgrencilerTbl.Find(TC);
            if (ogrencilerVt == null)
            {
                return NotFound();
            }
            return View(ogrencilerVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Ogrenciler? ogrenciler = _uygulamaDbContext.OgrencilerTbl.Find(id);
            if (ogrenciler == null)
            {
                return NotFound();
            }
            _uygulamaDbContext.OgrencilerTbl.Remove(ogrenciler);
            _uygulamaDbContext.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");
        }

    }
}
