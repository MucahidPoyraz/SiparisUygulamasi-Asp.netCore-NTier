using Farmasi.BL.Concrete;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Abstract
{
    public interface ISiparisService : IGenericService<Siparis>
    {
        List<Siparis> SiparisGetir(int id);
    }
}
