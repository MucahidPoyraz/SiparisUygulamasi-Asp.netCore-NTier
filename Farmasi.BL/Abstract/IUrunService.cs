using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Abstract
{
    public interface IUrunService :  IGenericService<Urun>
    {
        List<Urun> UrunGetir(int id);
    }
}
