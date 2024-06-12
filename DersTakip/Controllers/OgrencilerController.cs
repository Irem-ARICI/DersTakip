using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DersTakip.Controllers
{
    [Authorize(Roles=UserRoles.Role_Admin)]
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

        public IActionResult OgrenciEKleGuncelle(long? id)
        {
            IEnumerable<SelectListItem> OgrencilerList = _ogrencilerRepository.GetAll()
                .Select(k => new SelectListItem
                 {
                     Text = k.AdSoyad,
                     Value = k.Id.ToString(),
                 });
            ViewBag.OgrenciList = OgrencilerList;

            if ( id == 0 || id == null)
            {
                return View();
            }
            else
            {
                Ogrenciler? ogrencilerVt = _ogrencilerRepository.Get(u => u.Id == id);       // Expression<Func<T, bool>> filtre
                if (ogrencilerVt == null)
                {
                    return NotFound();
                }
                return View(ogrencilerVt);
            }
            
        }

        [HttpPost]
        public IActionResult OgrenciEKleGuncelle(Ogrenciler ogrenciler)    //  IFormFile? file
        {
            if(ModelState.IsValid)
            {
                _ogrencilerRepository.Guncelle(ogrenciler);
                _ogrencilerRepository.Kaydet();
                TempData["basarili"] = "Yeni öğrenci kaydedildi.";
                return RedirectToAction("Index");
            }
            return View();
        }

        /*

        public IActionResult Guncelle(long? id)  // TC yi yemedi ~OgretmenlerController->id 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Ogrenciler? ogrencilerVt = _ogrencilerRepository.Get(u => u.Id == id);       // Expression<Func<T, bool>> filtre
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
                _ogrencilerRepository.Guncelle(ogrenciler);
                _ogrencilerRepository.Kaydet();
                TempData["basarili"] = "Öğrenci bilgileri güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }

         */

        public IActionResult Sil(int? id)  // TC yi yemedi ~OgretmenlerController->id 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Ogrenciler? ogrencilerVt = _ogrencilerRepository.Get(u=>u.Id == id);
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
            _ogrencilerRepository.Sil(ogrenciler);
            _ogrencilerRepository.Kaydet();
            TempData["basarili"] = "Öğrenci listeden silinddi.";
            return RedirectToAction("Index", "Ogrenciler");
        }

    }
}
