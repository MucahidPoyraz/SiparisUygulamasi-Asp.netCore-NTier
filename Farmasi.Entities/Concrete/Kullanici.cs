using Farmasi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Kullanici : BaseEntity
    {
        public  string Resim { get; set; }

        public  string KullanıcıAdSoyad { get; set; }

        public  string Email { get; set; }

        public  string Parola { get; set; }
    }
}
