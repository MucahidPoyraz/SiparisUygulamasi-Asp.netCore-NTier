using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminKullaniciController : Controller
    {
        private readonly IGenericService<Kullanici> _kullanici;

        public AdminKullaniciController(IGenericService<Kullanici> kullanici)
        {
            _kullanici = kullanici;
        }

        public IActionResult KullaniciListele()
        {
            var gelenler =_kullanici.HepsiniGetirBl();
            TempData["Baslik"] = " Kullanıcı";
            return View(gelenler);
        }

       
        [Authorize]
        public IActionResult KullaniciEkle()
        {
            TempData["Baslik"] = " Kullanıcı Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(Kullanici p, IFormFile Resim)
        {
            if (!ModelState.IsValid)
            {
                return View("KullaniciEkle", p);
            }
            if (Resim != null)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + resimAd);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Resim.CopyToAsync(stream);
                }
                p.Resim = resimAd;
            }
            else
            {
                p.Resim = "default.jpg";
            }




            _kullanici.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile yapıldı";
            return RedirectToAction("KullaniciListele");
        }
        [Authorize]
        public IActionResult KullaniciSil(int id)
        {
            _kullanici.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("KullaniciListele");
        }
        [Authorize]
        public IActionResult KullaniciGuncelle(int id)
        {
            ViewBag.state = "update";

            var guncellenecek = _kullanici.IdileGetirBl(id);
            TempData["Baslik"] = " Kullanıcı Guncelle";

            return View("KullaniciEkle", guncellenecek);
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciGuncelle(Kullanici p, IFormFile Resim)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.state = "update";
                return View("KullaniciEkle", p);
            }
            if (Resim != null)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + resimAd);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Resim.CopyToAsync(stream);
                }
                p.Resim = resimAd;
            }

            _kullanici.GuncelleBl(p);
            TempData["Guncellendi"] = "Guncelleme işlemi başarılı bir şkilde yapıldı";
            return RedirectToAction("KullaniciListele");
        }
    }
}
