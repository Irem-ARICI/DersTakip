using DersTakip.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DersTakip.Controllers
{
    public class IsteklerController : Controller
    {
        private readonly IIsteklerRepository _isteklerRepository;
        private readonly IOgretmenlerRepository _ogretmenlerRepository;
        private readonly IOgrencilerRepository? _ogrencilerRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;
        private IOgrencilerRepository? ogrencilerRepository;

        public IsteklerController(IIsteklerRepository isteklerRepository, IOgretmenlerRepository ogretmenlerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _isteklerRepository = isteklerRepository;
            _ogretmenlerRepository = ogretmenlerRepository;
            _ogrencilerRepository = ogrencilerRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Istekler> objIsteklerList = _isteklerRepository.GetAll(/*includeProps:*/ /*"Ogretmenler"*/).ToList();  // "OgretmnelerId" de olabilir => forieng key bakaıcağğz
            return View(objIsteklerList);
        }
 

        // Get
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> OgrencilerList = _ogrencilerRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.AdSoyad,
                    Value = k.Id.ToString()
                });
            ViewBag.KitapList = OgrencilerList;

            if (id == null || id == 0)
            {
                // ekle
                return View();
            }
            else
            {
                // guncelleme
                Istekler? isteklerVt = _isteklerRepository.Get(u => u.Id == id);  // Expression<Func<T, bool>> filtre
                if (isteklerVt == null)
                {
                    return NotFound();
                }
                return View(isteklerVt);
            }

        }



        [HttpPost]
        public IActionResult EkleGuncelle(Istekler istekler)    // resim gonderme olmadigi icin =>  IFormFile? file --> sildik
        {

            if (ModelState.IsValid)
            {
                if (istekler.Id == 0)
                {
                    _isteklerRepository.Ekle(istekler);
                    TempData["basarili"] = "Yeni istek Kaydı başarıyla oluşturuldu!";
                }
                else
                {
                    _isteklerRepository.Guncelle(istekler);
                    TempData["basarili"] = "İstwk Kayıt güncelleme başarılı!";
                }

                _isteklerRepository.Kaydet(); // SaveChanges() yapmazsanız bilgiler veri tabanına eklenmez!			
                return RedirectToAction("Index", "Istekler");
            }
            return View();
        }




        // GET ACTION
        public IActionResult Sil(int? id)
        {
            //IEnumerable<SelectListItem> OgrencilerList = _ogrencilerRepository.GetAll()
            //    .Select(k => new SelectListItem
            //    {
            //        Text = k.AdSoyad,
            //        Value = k.Id.ToString()
            //    });
            //ViewBag.OgrencilerList = OgrencilerList;

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Istekler? isteklerVt = _isteklerRepository.Get(u => u.Id == id);
            if (isteklerVt == null)
            {
                return NotFound();
            }
            return View(isteklerVt);
        }


        [HttpPost, /*ActionName("Sil")*/]
        public IActionResult SilPOST(int? id)
        {
            Istekler? istekler = _isteklerRepository.Get(u => u.Id == id);
            if (istekler == null)
            {
                return NotFound();
            }
            _isteklerRepository.Sil(istekler);
            _isteklerRepository.Kaydet();
            TempData["basarili"] = "İstek Silme işlemi başarılı!";
            return RedirectToAction("Index", "Istekler");
        }






    }
}
