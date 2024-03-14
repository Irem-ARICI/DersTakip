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
            return View();
        }
    }
}
