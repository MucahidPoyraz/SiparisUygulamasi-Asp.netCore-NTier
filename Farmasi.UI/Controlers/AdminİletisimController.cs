using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminİletisimController : Controller
    {
        private readonly IGenericService<İletisim> _iletisim;
public AdminİletisimController(IGenericService<İletisim> iletisim)
        {
            _iletisim = iletisim;
        }

        public IActionResult İletisimListele()
        {
            var gelenler = _iletisim.HepsiniGetirBl();
            TempData["Baslik"] = " İletisim";
            return View(gelenler);
        }

        public IActionResult İletisimEkle()
        {
            TempData["Baslik"] = " İletisim Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult İletisimEkle(İletisim p)
        {

            if (!ModelState.IsValid)
            {
                return View("İletisimEkle", p);
            }

            _iletisim.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile yapıldı";
            return RedirectToAction("İletisimListele");

        }
        [Authorize]
        public IActionResult İletisimSil(int id)
        {
            _iletisim.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("İletisimListele");
        }
        [Authorize]
        public IActionResult İletisimGuncelle(int id)
        {
            ViewBag.state = "update";

            var guncellenecek = _iletisim.IdileGetirBl(id);
            TempData["Baslik"] = " İletisim guncelle";
            return View("İletisimEkle", guncellenecek);
        }

        [HttpPost]
        public IActionResult İletisimGuncelle(İletisim p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.state = "update";
                return View("İletisimEkle", p);
            }
            TempData["Guncellendi"] = "Guncelleme işlemi başarılı bir şekilde yapıldı";
            _iletisim.GuncelleBl(p);
            return RedirectToAction("İletisimListele");
        }
    }
}
