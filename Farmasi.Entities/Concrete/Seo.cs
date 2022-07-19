using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.Entities.Concrete
{
    public class Seo : BaseEntity
    {
        public string description { get; set; }
        public string keywords { get; set; }
        public string author { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
    }
}
