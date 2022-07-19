using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class HomeController : Controller
    {
        private readonly IGenericService<KategoriOne> _one;
        private readonly IGenericService<KategoriTwo> _two;
        private readonly IUrunSepetService _urunsepet;
        private readonly IGenericService<Slider> _slider;
        private readonly IGenericService<İletisim> _iletisim;
        //private readonly IGenericService<Hakkimizda> _hakkimizda;
        private readonly IGenericService<Seo> _seo;

        public HomeController(IGenericService<KategoriOne> one, IGenericService<KategoriTwo> two, IUrunSepetService urunsepet, IGenericService<Slider> slider, IGenericService<İletisim> iletisim, /*IGenericService<Hakkimizda> hakkimizda,*/ IGenericService<Seo> seo)
        {
            _one = one;
            _two = two;
            _urunsepet = urunsepet;
            _slider = slider;
            _iletisim = iletisim;
            //_hakkimizda = hakkimizda;
            _seo = seo;
        }

        public IActionResult Index()
       {

            var ust = _one.HepsiniGetirBl("KategoriTwos");
            var alt = _two.HepsiniGetirBl();
            var varmı = HttpContext.Session.GetInt32("session");
            var adet = 0;
            if(varmı != null)
            {
                adet = _urunsepet.UrunSepetGetir("Urun",varmı.Value).Count();
            }
            ViewBag.Iletisim = _iletisim.HepsiniGetirBl().FirstOrDefault();
            //ViewBag.Hakkimizda = _hakkimizda.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Slider = _slider.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Seo = _seo.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Adet = adet;
            ViewBag.UstKategori = ust;
            ViewBag.AltKategori = alt;
            return View();
        }

        
    }
}
