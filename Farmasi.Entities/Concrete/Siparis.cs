using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Siparis : BaseEntity
    {
       
        public virtual string AdSoyad { get; set; }
        public virtual string Email { get; set; }
        public virtual string Telefon { get; set; }
        public  string Adres { get; set; }
        public  int SesionId { get; set; }
        public bool Durum { get; set; } = false;
        public  DateTime SiparisZamani { get; set; } = DateTime.Now;
        public  List<Urun> Uruns { get; set; }
    }
}
