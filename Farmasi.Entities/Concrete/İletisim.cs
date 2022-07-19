using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class İletisim : BaseEntity
    {
        public string Adres { get; set; }

        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Facebook { get; set; }

        public string Youtube { get; set; }

        public string WebSite { get; set; }

        public string MapLink { get; set; }
    }
}
