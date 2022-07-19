using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class AdminSeoController : Controller
    {
        private readonly IGenericService<Seo> _seo;

        public AdminSeoController(IGenericService<Seo> seo)
        {
            _seo = seo;
        }

        public IActionResult SeoListele()
        {
            var gelenler = _seo.HepsiniGetirBl();
            TempData["Baslik"] = " Seo";
            return View(gelenler);
        }

        public IActionResult SeoEkle()
        {
            TempData["Baslik"] = " Seo Ekle";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SeoEkle(Seo p, IFormFile icon)
        {
            if (icon != null)
            {
                string uzanti = Path.GetExtension(icon.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + resimAd);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await icon.CopyToAsync(stream);
                }

                p.icon = resimAd;
            }
            else
            {
                p.icon = "default.jpg";
            }
            _seo.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile yapıldı";
            return RedirectToAction("SeoListele");
        }

        public IActionResult SeoSil(int id)
        {
            _seo.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("SeoListele");
        }

        public IActionResult SeoGuncelle(int id)
        {
            ViewBag.state = "update";
            var gelenler = _seo.IdileGetirBl(id);
            TempData["Baslik"] = " Seo Guncelle";
            return View("SeoEkle", gelenler);
        }

        [HttpPost]
        public async Task<IActionResult> SeoGuncelle(Seo p, IFormFile icon)
        {
            if (icon != null)
            {
                string uzanti = Path.GetExtension(icon.FileName);
                string resimAd = Guid.NewGuid() + uzanti;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/" + resimAd);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await icon.CopyToAsync(stream);
                }

                p.icon = resimAd;
            }

            _seo.GuncelleBl(p);
            TempData["Guncellendi"] = "Guncelleme işlemi başarılı bir şekilde yapıldı";
            return RedirectToAction("SeoListele");
        }
    }
}
