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
    public class SepetController : Controller
    {
        private readonly IGenericService<Sepet> _sepet;
        private readonly IGenericService<Urun> _urun;
        private readonly IGenericService<UrunSepet> _urunsepet;
        private readonly IUrunSepetService _urunsepetservice;
        private readonly IGenericService<KategoriOne> _one;
        private readonly IGenericService<KategoriTwo> _two;
        private readonly IGenericService<Siparis> _siparis;
        private readonly IGenericService<SiparisUrun> _siparisurun;
        private readonly IGenericService<İletisim> _iletisim;
        private readonly IGenericService<Seo> _seo;
        private readonly ISiparisService _siparisservice;



        public SepetController(IGenericService<Sepet> sepet, IGenericService<Urun> urun, IGenericService<UrunSepet> urunsepet, IUrunSepetService urunsepetservice, IGenericService<KategoriOne> one, IGenericService<KategoriTwo> two, IGenericService<Siparis> siparis, IGenericService<SiparisUrun> siparisurun, ISiparisService siparisservice, IGenericService<İletisim> iletisim, IGenericService<Seo> seo)
        {
            _sepet = sepet;
            _urun = urun;
            _urunsepet = urunsepet;
            _urunsepetservice = urunsepetservice;
            _one = one;
            _two = two;
            _siparis = siparis;
            _siparisurun = siparisurun;
            _siparisservice = siparisservice;
            _iletisim = iletisim;
            _seo = seo;
        }

        public IActionResult SepetListele()
        {
            ViewBag.Seo = _seo.HepsiniGetirBl().FirstOrDefault();
            ViewBag.Iletisim = _iletisim.HepsiniGetirBl().FirstOrDefault();
            var adet = 0;
            decimal toplam = 0;
            var varmı = HttpContext.Session.GetInt32("session");
            if (varmı > 0 && varmı != null)
            {
                var sepeturunler = _urunsepetservice.UrunSepetGetir("Urun", varmı.Value);
                //foreach (var item in sepeturunler)
                //{
                //    if (item.SesionKod != varmı.Value)
                //    {
                //        sepeturunler.Remove(item);
                //    }
                //}
                var ust = _one.HepsiniGetirBl("KategoriTwos");
                var alt = _two.HepsiniGetirBl();


                adet = sepeturunler.Count();

                foreach (var item in sepeturunler)
                {
                    toplam = toplam + (item.Urun.Fiyat * item.Adet);
                }




                //foreach (var item in sepeturunler)
                //{
                //    if (item.SepetId == varmı.Value)
                //    {
                //        toplam = (int)(item.Adet * item.Urun.Fiyat);
                //    }

                //}
                ViewBag.Toplam = toplam;
                ViewBag.Adet = adet;
                ViewBag.UstKategori = ust;
                ViewBag.AltKategori = alt;
                ViewBag.Kontrol = varmı.Value;
                return View(sepeturunler);
            }
            else
            {
                TempData["SepetBos"] = "Sepetinizde hiç ürün yok!!!";
                return RedirectToAction("Index", "Home");
            }


        }

        public IActionResult SepetEkle(int id)
        {
            var varmı = HttpContext.Session.GetInt32("session");
            var urunvar = 0;
            var urunId = 0;
            if (varmı > 0 && varmı != null)
            {
                var kontrol = _urunsepetservice.HepsiniGetirBl(varmı.Value);
                if (kontrol != null)
                {
                    foreach (var item in kontrol)
                    {
                        if (item.UrunId == id)
                        {
                            urunvar = 1;
                            urunId = item.ID;
                        }
                    }
                    if(urunvar != 0)
                    {
                        SepetArttir(urunId);
                    }
                    else
                    {
                        var urunsepet = new UrunSepet { UrunId = id, SepetId = varmı.Value, Adet = 1 };

                        var sepetekle = _sepet.IdileGetirBl(varmı.Value);
                        var urun = _urun.IdileGetirBl(id);
                        sepetekle.ToplamFiyat = sepetekle.ToplamFiyat + urun.Fiyat;
                        _sepet.GuncelleBl(sepetekle);
                        //urunsepet.Adet = urunsepet.Adet + 1;
                        _urunsepet.EkleBl(urunsepet);
                    }
                    



                } }
            else
            {
                var sepetekle = new Sepet { ID = 0, SesionKod = 0 };
                _sepet.EkleBl(sepetekle);
                sepetekle.SesionKod = sepetekle.ID;

                _sepet.GuncelleBl(sepetekle);

                HttpContext.Session.SetInt32("session", sepetekle.SesionKod);
                var urunsepet = new UrunSepet { UrunId = id, SepetId = sepetekle.ID, Adet = 1 };

                var urun = _urun.IdileGetirBl(id);
                sepetekle.ToplamFiyat = +urun.Fiyat;
                _sepet.GuncelleBl(sepetekle);

                _urunsepet.EkleBl(urunsepet);


          
            }
           
           
            
            return RedirectToAction("UrunDetay","Urun",new {ID = id});
        }

        public IActionResult SepetAzalt(int id)
        {
            var urun = _urunsepetservice.IdileGetirBl(id);
            urun.Adet = urun.Adet - 1;
           
            _urunsepet.GuncelleBl(urun);
            if (urun.Adet <= 0)
            {
                _urunsepet.SilBl(urun.ID);
            }
            return RedirectToAction("SepetListele");
        }

        public IActionResult SepetArttir(int id)
        {
                 
            var urun = _urunsepetservice.IdileGetirBl(id);
            urun.Adet = urun.Adet + 1;
            
            _urunsepet.GuncelleBl(urun);
            return RedirectToAction("SepetListele");
        }

        public IActionResult SepetSil(int id)
        {
            var varmı = HttpContext.Session.GetInt32("session");
            var urun = _urunsepetservice.IdileGetirBl(id);
            _urunsepet.SilBl(urun.ID);

            var miktar = _urunsepetservice.UrunSepetGetir("Urun",varmı.Value).Count();
            if(miktar <= 0)
            {
                return RedirectToAction("Index","Home");
            }

            return RedirectToAction("SepetListele");
        }

        public IActionResult SiparisEkle(Siparis p)
        {
           
            var varmı = HttpContext.Session.GetInt32("session");
            p.SesionId = varmı.Value;
            _siparis.EkleBl(p);
            var siparisler  = _urunsepetservice.UrunSepetGetir("Urun", varmı.Value);
            var sipid = _siparisservice.SiparisGetir(varmı.Value).FirstOrDefault().ID;
            foreach (var item in siparisler)
            {
                var siparisekle = new SiparisUrun { ID = 0, SiparisId=sipid,UrunId = item.UrunId, Adet = item.Adet};
                _siparisurun.EkleBl(siparisekle);
                _urunsepet.SilBl(item.ID);
            }
           
            
            return RedirectToAction("SepetListele");
        }
    }
}
