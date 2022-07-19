using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class UrunSepet : BaseEntity
    {
        public  int UrunId { get; set; }
        public  Urun Urun { get; set; }
        public  int SepetId { get; set; }
        public  Sepet Sepet { get; set; }
        public  int Adet { get; set; }
    }
}
