using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class KategoriOne : BaseEntity
    {
        public  string Ad { get; set; }
        public  List<KategoriTwo> KategoriTwos { get; set; }
    }
}
