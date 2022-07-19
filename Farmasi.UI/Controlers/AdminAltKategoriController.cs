using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminAltKategoriController : Controller
    {
        private readonly IAltKategoriService _two;
        private readonly IGenericService<KategoriOne> _one;

        public AdminAltKategoriController(IAltKategoriService two, IGenericService<KategoriOne> one)
        {
            _two = two;
            _one = one;
        }
        public IActionResult AltKategoriListele(int id)
        {
            var ustkat = _one.IdileGetirBl(id).Ad;
            var gelenler = _two.AltKAtegoriGetir(id);
            TempData["Baslik"] =ustkat + "' a ait kategoriler";
            ViewBag.Ustkategori = id;
            return View(gelenler);
        }

        public IActionResult AltKategoriEkle(int id)
        {
            var ustkat = _one.IdileGetirBl(id).Ad;
            TempData["Baslik"] = ustkat + "' a ait kategori Ekle";
            ViewBag.Ustkategori = id;
            return View();
        }

        [HttpPost]
        public IActionResult AltKategoriEkle(KategoriTwo p)
        {
            _two.EkleBl(p);
            var id = p.KategoriOneId;
            TempData["Ekleme"] = "Ekleme işlemi başarı ile eklendi";
            return RedirectToAction("AltKategoriListele",new { ID = id});
        }

        public IActionResult AltKategoriGuncelle(int id)
        {
            var geleneler = _two.IdileGetirBl(id);
            var ustkat = _one.IdileGetirBl(geleneler.KategoriOneId).Ad;
            TempData["Baslik"] = ustkat + " / " + geleneler.Ad + " guncelle";
            ViewBag.state = "update";
            return View("AltKategoriEkle", geleneler);
        }

        [HttpPost]
        public IActionResult AltKategoriGuncelle(KategoriTwo p)
        {
            _two.GuncelleBl(p);
            var id = p.KategoriOneId;
            TempData["Guncelleme"] = "Guncelleme işlemi başarı ile eklendi";
            return RedirectToAction("AltKategoriListele",new { ID = id});
        }

        public IActionResult AltKategoriSil(int id)
        {
            var gelen = _two.IdileGetirBl(id);
            var Id = gelen.KategoriOneId;
            _two.SilBl(id);

            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("AltKategoriListele",new { ID = id});
        }
    }
}
