using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Mvc;

namespace DersTakip.Controllers
{
    public class OgrencilerController : Controller
    {
        private readonly IOgrencilerRepository _ogrencilerRepository;
        public OgrencilerController(IOgrencilerRepository context)
        {
            _ogrencilerRepository = context;
        }
        public IActionResult Index()
        {
            List<Ogrenciler> objOgrencilerList = _ogrencilerRepository.GetAll().ToList();
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
                _ogrencilerRepository.Ekle(ogrenciler);
                _ogrencilerRepository.Kaydet();
                TempData["basarili"] = "Yeni öğrenci kaydedildi.";
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
            Ogrenciler? ogrencilerVt = _ogrencilerRepository.Get(u => u.Sinifi = Sinifi);       // Expression<Func<T, bool>> filtre
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
                _ogrencilerRepository.Ekle(ogrenciler);
                _ogrencilerRepository.Kaydet();
                TempData["basarili"] = "Öğrenci bilgileri güncellendi.";
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
            Ogrenciler? ogrencilerVt = _ogrencilerRepository.Get(u=>u.TC = TC);
            if (ogrencilerVt == null)
            {
                return NotFound();
            }
            return View(ogrencilerVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Ogrenciler? ogrenciler = _ogrencilerRepository.Get(u => u.Id == id);
            if (ogrenciler == null)
            {
                return NotFound();
            }
            _ogrencilerRepository.Ekle(ogrenciler);
            _ogrencilerRepository.Kaydet();
            TempData["basarili"] = "Öğrenci listeden silinddi.";
            return RedirectToAction("Index", "Ogrenciler");
        }

    }
}
