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
    public class AdminSliderController : Controller
    {
        private readonly IGenericService<Slider> _slider;

        public AdminSliderController(IGenericService<Slider> slider)
        {
            _slider = slider;
        }

        public IActionResult SliderListele()
        {
            var gelenler =  _slider.HepsiniGetirBl();
            TempData["Baslik"] = " Slider";
            return View(gelenler);
        }

        public IActionResult SliderEkle()
        {
            TempData["Baslik"] = " Slider Ekle";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> SliderEkle(Slider p, IFormFile Resim)
        {
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
             _slider.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile yapıldı";
            return RedirectToAction("SliderListele");
        }

        public IActionResult SliderSil(int id)
        {
             _slider.SilBl(id);
            TempData["Silindi"] = "Silme işlemi başarılı";
            return RedirectToAction("SliderListele");
        }

        public IActionResult SliderGuncelle(int id)
        {
            ViewBag.state = "update";
            var gelenler =  _slider.IdileGetirBl(id);
            TempData["Baslik"] = " Slider Guncelle";
            return View("SliderEkle", gelenler);
        }

        [HttpPost]
        public async Task<IActionResult> SliderGuncelle(Slider p, IFormFile Resim)
        {
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

             _slider.GuncelleBl(p);
            TempData["Guncellendi"] = "Guncelleme işlemi başarılı bir şekilde yapıldı";
            return RedirectToAction("SliderListele");
        }
    }
}
