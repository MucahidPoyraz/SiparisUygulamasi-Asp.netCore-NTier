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
    public class UrunDetayController : Controller
    {
        private readonly IGenericService<Urun> _urun;
        private readonly IUrunSepetService _urunsepetservice;

        public UrunDetayController(IGenericService<Urun> urun, IUrunSepetService urunsepetservice)
        {
            _urun = urun;
            _urunsepetservice = urunsepetservice;
        }

        public IActionResult Index(int id)
        {
            var gelen = _urun.IdileGetirBl(id);
            var varmı = HttpContext.Session.GetInt32("session");
            var adet = 0;
            if (varmı != null)
            {
                adet = _urunsepetservice.UrunSepetGetir("Urun",varmı.Value).Count();
            }
            ViewBag.Adet = adet;
            return View(gelen);
        }
    }
}
