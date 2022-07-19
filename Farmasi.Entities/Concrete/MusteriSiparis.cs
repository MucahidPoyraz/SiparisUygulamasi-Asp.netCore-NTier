using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class MusteriSiparis : BaseEntity
    {
        public  Urun Urun { get; set; }
        public  Musteri Musteri { get; set; }
        public  int Adet { get; set; }
    }
}
