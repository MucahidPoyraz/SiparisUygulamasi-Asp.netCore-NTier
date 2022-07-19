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
    public class AdminUrunController : Controller
    {
        private readonly IUrunService _urun;
        private readonly IGenericService<KategoriOne> _one;
        private readonly IGenericService<KategoriTwo> _two;

        public AdminUrunController(IUrunService urun, IGenericService<KategoriOne> one, IGenericService<KategoriTwo> two)
        {
            _urun = urun;
            _one = one;
            _two = two;
        }

        public IActionResult UrunListele(int id)
        {
            var gelenler = _urun.UrunGetir(id);
            ViewBag.KategoriTwoId = id;
            
            var altkat = _two.IdileGetirBl(id);
            var ustkat = _one.IdileGetirBl(altkat.KategoriOneId).Ad;
            TempData["Baslik"] = ustkat + " / " + altkat.Ad + " Urunleri";
            return View(gelenler);
        }

        public IActionResult UrunEkle(int id)
        {
            ViewBag.KategoriTwoId = id;
            var altkat = _two.IdileGetirBl(id);
            var ustkat = _one.IdileGetirBl(altkat.KategoriOneId).Ad;
            TempData["Baslik"] = ustkat + " / " + altkat.Ad + " Urun Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(Urun p, IFormFile Resim)
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

            _urun.EkleBl(p);
            TempData["Ekleme"] = "Ekleme işlemi başarı ile eklendi";
            var id = p.KategoriTwoId;
            return RedirectToAction("UrunListele", new { id = id });

            
        }

        public IActionResult UrunGuncelle(int id)
        {
            
           
            var guncellenecek = _urun.IdileGetirBl(id);
            var altkat = _two.IdileGetirBl(guncellenecek.KategoriTwoId);
            var ustkat = _one.IdileGetirBl(altkat.KategoriOneId).Ad;
            TempData["Baslik"] = ustkat + " / " + altkat.Ad + " Urun Guncelle";
            ViewBag.state = "update";
            return View("UrunEkle",guncellenecek);
        }

        [HttpPost]
        public async Task<IActionResult> UrunGuncelle(Urun p, IFormFile Resim)
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

            _urun.EkleBl(p);
            TempData["Guncelleme"] = "Guncelleme işlemi başarı ile eklendi";
            var id = p.KategoriTwoId;
            return RedirectToAction("UrunListele", new { id = id });


        }

        public IActionResult UrunSil(int id)
        {
            var silinecek = _urun.IdileGetirBl(id);
            ViewBag.KategoriTwoId = silinecek.KategoriTwoId;
            TempData["Silindi"] = "Silme işlemi başarılı";
            return View("UrunListele", new { id = id });
        }



    }
}
