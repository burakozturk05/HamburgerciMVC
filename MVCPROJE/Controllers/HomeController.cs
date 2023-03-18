using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCPROJE.Context;
using MVCPROJE.Data;
using MVCPROJE.Models;
using System.Diagnostics;

namespace MVCPROJE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;
        public HomeController(ILogger<HomeController> logger,UygulamaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Ekle() //Ekleme formuna gidecek. Ekleme formunda da bu sefer post olan Ekle Action ına gidecek.
        {
            return View();
        }
        public IActionResult Sil(int id) //o gönderilen id yi burada yakalıyoruz ve o  id ye ait olan ürünü silip, tekrar ana listeye redirect yapıyoruz.
        {
            var silinecekUrun = _db.Urunler.Find(id);
            _db.Urunler.Remove(silinecekUrun);
            _db.SaveChanges();
            return RedirectToAction("SiparisBilgileri");

        }
        public IActionResult Guncelle(int id)
        {
            //Ana listeden ürünün yanındaki güncelle butonuna basıldığında,
            //id'yi silme işlemi gibi burada yakalayıp o ürünü getirip
            //o ürünü yine kendi view'ına göndereceğiz.
            return View(_db.Urunler.Find(id));

        }
        [HttpPost]
        public IActionResult Guncelle(Urun urun) //Guncelle view ından post ile modeli yakala.
        {
            //Gönderilen ürünü güncelle.
            _db.Urunler.Update(urun);
            _db.SaveChanges();
            return RedirectToAction("SiparisBilgileri");

        }
        [HttpPost]
        public IActionResult Ekle(Urun urun)
        {
            //Formdan gelen ürünü DB'ye EKLE...
            _db.Urunler.Add(urun);
            _db.SaveChanges();
            return RedirectToAction("SiparisBilgileri");
        }
        public IActionResult SiparisYonetimi()
        {
            return View();
        }
        public IActionResult UrunYonetimi()
        {
            return View();
        }
        public IActionResult SiparisBilgileri()
        {
            var urunler = _db.Urunler.ToList();
            var extramalzeme = _db.ExtraMalzemes.ToList();
            ViewBag.Tutar1 = extramalzeme.Sum(x => x.Fiyat);
            ViewBag.Tutar = urunler.Sum(x => x.Fiyat);
            return View(urunler);
            
        }
        public IActionResult SiparisOlustur()
        {
            return View();
        }
        public IActionResult ExtraMalzeme() //GET Eklme formunu getiriyor.
        {
           
            return View();
            
        }
       public IActionResult ExtraEkle()
        {
			
			return View();
        }
        [HttpPost]
        public IActionResult ExtraEkle(ExtraMalzeme malzeme)
        {
			_db.ExtraMalzemes.Add(malzeme);
			_db.SaveChanges();
			return RedirectToAction("EklenmisMalzeme");
			
        }
        public IActionResult EklenmisMalzeme()
        {
            var extramalzeme = _db.ExtraMalzemes.ToList();
            ViewBag.Tutar = extramalzeme.Sum(x => x.Fiyat);
            var malzeme = _db.ExtraMalzemes.ToList();
            return View(malzeme);
        }
        public IActionResult ExtraSil(int id)
        {
            var extrasil = _db.ExtraMalzemes.Find(id);
            _db.ExtraMalzemes.Remove(extrasil);
            _db.SaveChanges();
            return RedirectToAction("EklenmisMalzeme");
        }
        public IActionResult ExtraGuncelle()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}