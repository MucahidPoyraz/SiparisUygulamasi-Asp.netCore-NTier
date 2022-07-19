using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminSiparislerController : Controller
    {
        private readonly IGenericService<Siparis> _siparis;
        private readonly IUrunSiparisService _siparisdetay;

        public AdminSiparislerController(IGenericService<Siparis> siparis, IUrunSiparisService siparisdetay)
        {
            _siparis = siparis;
            _siparisdetay = siparisdetay;
        }

        public IActionResult SiparisListele()
        {
            var gelenler = _siparis.HepsiniGetirBl().OrderByDescending(x=>x.SiparisZamani).ToList();
            TempData["Baslik"] = " Siparişler ";
            return View(gelenler);
        }

        public IActionResult SiparisDetay(int id)
        {
            var gelenler = _siparisdetay.UrunSiparisGetir("Urun",id);
            var siparis = _siparis.IdileGetirBl(id);
            TempData["Baslik"] =siparis.AdSoyad +" / " + siparis.SiparisZamani;
            return View(gelenler);
        }
        public IActionResult SiparisDurum(int id)
        {
            var siparis = _siparis.IdileGetirBl(id);
            siparis.Durum = !siparis.Durum;
            _siparis.GuncelleBl(siparis);
            return RedirectToAction("SiparisListele");
        }

      
    }
}
