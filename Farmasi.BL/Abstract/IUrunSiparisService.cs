using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Abstract
{
    public interface IUrunSiparisService : IGenericService<SiparisUrun>
    {
        List<SiparisUrun> UrunSiparisGetir(string p, int id);
    }
}
