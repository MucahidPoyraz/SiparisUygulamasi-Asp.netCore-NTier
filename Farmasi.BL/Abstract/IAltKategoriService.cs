using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Abstract
{
    public interface IAltKategoriService : IGenericService<KategoriTwo>
    {
        List<KategoriTwo> AltKAtegoriGetir(int id);
    }
}
