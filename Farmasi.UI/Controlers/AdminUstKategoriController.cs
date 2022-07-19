using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminUstKategoriController : Controller
    {
        private readonly IGenericService<KategoriOne> _one;

        public AdminUstKategoriController(IGenericService<KategoriOne> one)
        {
            _one = one;
        }
        public IActionResult UstKategoriListele()
        {
            var gelenler = _one.HepsiniGetirBl();
            TempData["Baslik"] = "Birincil Kategoriler";
            return View(gelenler);
        }

        public IActionResult UstKategoriEkle()
        {
            TempData["Baslik"] = "Birincil Kategori Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult UstKategoriEkle(KategoriOne p)
        {
            _one.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile eklendi";
            return RedirectToAction("UstKategoriListele");
        }

        public IActionResult UstKategoriGuncelle(int id)
        {
            var geleneler = _one.IdileGetirBl(id);
            TempData["Baslik"] =geleneler.Ad + " Kategori Guncelle";
            ViewBag.state = "update";
            return View("UstKategoriEkle", geleneler);
        }

        [HttpPost]
        public IActionResult UstKategoriGuncelle(KategoriOne p)
        {
            _one.GuncelleBl(p);
            TempData["Guncelleme"] = "Guncelleme işlemi başarı ile eklendi";
            return RedirectToAction("UstKategoriListele");
        }

        public IActionResult UstKategoriSil(int id)
        {
            _one.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("UstKategoriListele");
        }
    }
}
