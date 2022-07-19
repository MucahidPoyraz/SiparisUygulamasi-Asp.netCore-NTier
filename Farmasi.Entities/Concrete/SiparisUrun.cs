
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class SiparisUrun : BaseEntity
    {
        public  int UrunId { get; set; }
        public  Urun Urun { get; set; }
        public  int SiparisId { get; set; }
        public  Siparis Sipars { get; set; }
        public  int Adet { get; set; }
    }
}
