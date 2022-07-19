using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Farmasi.UI.Controlers
{
    public class UrunController : Controller
    {
        private readonly IGenericService<KategoriOne> _one;
        private readonly IGenericService<KategoriTwo> _two;
        private readonly IGenericService<Seo> _seo;
        private readonly IGenericService<İletisim> _iletisim;
        private readonly IUrunSepetService _urunSepetService;

        
        private readonly IUrunService _urun;


        public UrunController(IUrunService urun, IGenericService<KategoriOne> one, IGenericService<KategoriTwo> two, IUrunSepetService urunSepetService, IGenericService<Seo> seo, IGenericService<İletisim> iletisim)
        {

            _urun = urun;
            _one = one;
            _two = two;
            _urunSepetService = urunSepetService;
            _seo = seo;
            _iletisim = iletisim;
        }

        public IActionResult UrunListele(int id)
        {
            ViewBag.Seo = _seo.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Iletisim = _iletisim.HepsiniGetirBl().FirstOrDefault();
            var gelenler = _urun.UrunGetir(id);
            var ust = _one.HepsiniGetirBl("KategoriTwos");
            var alt = _two.HepsiniGetirBl();
            var varmı = HttpContext.Session.GetInt32("session");
            var adet = 0;
            if (varmı != null)
            {
                adet = _urunSepetService.UrunSepetGetir("Urun",varmı.Value).Count();
            }
            ViewBag.Adet = adet;
            ViewBag.UstKategori = ust;
            ViewBag.AltKategori = alt;
            return View(gelenler);
        }

        public IActionResult UrunDetay(int id)
        {
            ViewBag.Seo = _seo.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Iletisim = _iletisim.HepsiniGetirBl().FirstOrDefault();
            var urundetay = _urun.IdileGetirBl(id);
            var varmı = HttpContext.Session.GetInt32("session");
            var adet = 0;
            if (varmı != null)
            {
                adet = _urunSepetService.UrunSepetGetir("Urun",varmı.Value).Count();
            }
            ViewBag.Adet = adet;
            var ust = _one.HepsiniGetirBl("KategoriTwos");
            var alt = _two.HepsiniGetirBl();
            ViewBag.UstKategori = ust;
            ViewBag.AltKategori = alt;
            return View(urundetay);
        }


    }
}
