using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Urun : BaseEntity 
    {
        public  int UrunKod { get; set; }
        public  string Resim { get; set; }
        public  string Ad { get; set; }
        public  string Aciklama { get; set; }
        public  decimal Fiyat { get; set; }
        public  int KategoriTwoId { get; set; }
        public KategoriTwo KategoriTwo { get; set; }
        public virtual List<UrunSepet> UrunSepets { get; set; }
        public virtual List<Siparis> Siparis { get; set; }
    }
}
