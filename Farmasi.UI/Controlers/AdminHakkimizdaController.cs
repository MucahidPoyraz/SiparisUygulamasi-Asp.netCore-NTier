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
    public class AdminHakkimizdaController : Controller
    {
        private readonly IGenericService<Hakkimizda> _hakkimizda;

        public AdminHakkimizdaController(IGenericService<Hakkimizda> hakkimizda)
        {
            _hakkimizda = hakkimizda;
        }

        public IActionResult HakkimizdaListele()
        {
            var gelenler =_hakkimizda.HepsiniGetirBl();
           
            TempData["Baslik"] =  " Hakkımzıda";
            return View(gelenler);
        }

        public IActionResult HakkimizdaEkle()
        {
            TempData["Baslik"] = " Hakkımzıda Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult HakkimizdaEkle(Hakkimizda p)
        {

            if (!ModelState.IsValid)
            {
                return View("HakkimizdaEkle", p);
            }

            _hakkimizda.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile yapıldı";
            return RedirectToAction("HakkimizdaListele");

        }
        [Authorize]
        public IActionResult HakkimizdaSil(int id)
        {
            _hakkimizda.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("HakkimizdaListele");
        }
        [Authorize]
        public IActionResult HakkimizdaGuncelle(int id)
        {
            ViewBag.state = "update";

            var guncellenecek = _hakkimizda.IdileGetirBl(id);
            TempData["Baslik"] = " Hakkımzıda Guncelle";
            return View("HakkimizdaEkle", guncellenecek);
        }

        [HttpPost]
        public IActionResult HakkimizdaGuncelle(Hakkimizda p)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.state = "update";
                return View("HakkimizdaEkle", p);
            }
            TempData["Guncellendi"] = "Guncelleme işlemi başarılı bir şekilde yapıldı";
            _hakkimizda.GuncelleBl(p);
            return RedirectToAction("HakkimizdaListele");
        }
    }
}
