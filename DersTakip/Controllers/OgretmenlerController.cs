using DersTakip.Models;
using DersTakip.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DersTakip.Controllers
{
    public class OgretmenlerController : Controller
    {
        // Dependency injection

        private readonly IOgretmenlerRepository _ogretmenlerRepository;
        public OgretmenlerController(IOgretmenlerRepository context)
        {
            _ogretmenlerRepository = context;
        }
        public IActionResult Index()
        {
            String ornek = "merhaba";
            ViewBag.ornek = ornek;

            List<Ogretmenler> objOgretmenlerList = _ogretmenlerRepository.GetAll().ToList();
            return View(objOgretmenlerList);
        }

        public IActionResult OgretmenEkle()
        {
            IEnumerable<SelectListItem> OgretmenlerList = _ogretmenlerRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.Id.ToString(),
                });
            ViewBag.OgretmenlerList = OgretmenlerList;


            return View();
        }

        [HttpPost]
        public IActionResult OgretmenEkle(Ogretmenler ogretmenler, IFormFile? file)     // , IFormFile? file
        {
            //if (ModelState.IsValid)
         //   {
                _ogretmenlerRepository.Ekle(ogretmenler);
                _ogretmenlerRepository.Kaydet();   // YApmazsan veritabanına eklenmez. => SaveChanges();
                TempData["basarili"] = "Yeni öğretmen kaydedildi."; // TempData Controller ve View arasında geçişi göntülememizi sağlıyor
                return RedirectToAction("Index");    // "Ogretmenler" controllerını çağırıyoruz farklı bi cont. çağırcaksak kesin yazmak zorunda
         //   }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            Ogretmenler? ogretmenlerVt = _ogretmenlerRepository.Get(u=>u.Id==id);       // Expression<Func<T, bool>> filtre
            if (ogretmenlerVt == null)
            {
                return NotFound();
            }
            return View(ogretmenlerVt);
        }

        [HttpPost]
        public IActionResult Guncelle(Ogretmenler ogretmenler, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _ogretmenlerRepository.Guncelle(ogretmenler);
                _ogretmenlerRepository.Kaydet();   // YApmazsan veritabanına eklenmez. => SaveChanges(); ===> repository ekledik sonraağa
                TempData["basarili"] = "Öğretmen bilgileri güncellendi.";
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
            Ogretmenler? ogretmenlerVt = _ogretmenlerRepository.Get(u => u.Id == id);
            if (ogretmenlerVt == null)
            {
                return NotFound();
            }
            return View(ogretmenlerVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Ogretmenler? ogretmenler = _ogretmenlerRepository.Get(u => u.Id == id);
            if(ogretmenler == null)
            {
                return NotFound();
            }
            _ogretmenlerRepository.Sil(ogretmenler);
            _ogretmenlerRepository.Kaydet();
            TempData["basarili"] = "Öğretmen listeden silinddi.";
            return RedirectToAction("Index", "Ogretmenler");
        }


    }
}
