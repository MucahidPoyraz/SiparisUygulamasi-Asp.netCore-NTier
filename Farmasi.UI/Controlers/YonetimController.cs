using Farmasi.BL.Abstract;
using Farmasi.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Farmasi.UI.Controlers
{
    public class YonetimController : Controller
    {
        private readonly IGenericService<Kullanici> _kullanici;

        public YonetimController(IGenericService<Kullanici> kullanici)
        {
            _kullanici = kullanici;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult LoginKontrol(Kullanici p)
        {
            var info = _kullanici.HepsiniGetirBl().FirstOrDefault(
                //x => x.Email == p.Email &&      x.Parola == p.Parola
                );

            if (info != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"Admin")
                };
                var userIdentity = new ClaimsIdentity(claims, "Yonetim");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);

                return RedirectToAction("UstKategoriListele", "AdminUstKategori");
            }
            return RedirectToAction("Index", "Yonetim");

        }
    }
}
