using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class KategoriTwo : BaseEntity
    {
        public  string Ad { get; set; }
        public  int KategoriOneId { get; set; }
        public  KategoriOne KategoriOne { get; set; }
        public  List<Urun> Uruns { get; set; }
        
    }
}
