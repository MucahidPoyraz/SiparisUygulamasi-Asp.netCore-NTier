using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Sepet : BaseEntity 
    {
        public  int SesionKod { get; set; }
        public  List<UrunSepet> UrunSepets { get; set; }
        public  decimal ToplamFiyat { get; set; } 

    }
}
