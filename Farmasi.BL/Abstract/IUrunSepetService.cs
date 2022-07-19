using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Abstract
{
    public interface IUrunSepetService : IGenericService<UrunSepet>
    {
        List<UrunSepet> UrunSepetGetir(string p,int id);

        List<UrunSepet> HepsiniGetirBl(int id);
    }
}
