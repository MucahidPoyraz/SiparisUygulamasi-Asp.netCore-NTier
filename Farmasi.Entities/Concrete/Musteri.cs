using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Musteri : BaseEntity 
    {
        public  string AdSoyad { get; set; }
        public  string Email { get; set; }
        public  string Telefon { get; set; }
    }
}
