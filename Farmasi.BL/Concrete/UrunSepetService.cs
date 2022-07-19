using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Concrete
{
    public class UrunSepetService : GenericService<UrunSepet>, IUrunSepetService
    {
        private readonly IUrunSepetRepository _urun;
        public UrunSepetService(IGenericRepository<UrunSepet> repository, IUrunSepetRepository urun) : base(repository)
        {
            _urun = urun;
            
        }

        public List<UrunSepet> HepsiniGetirBl(int id)
        {
            return _urun.HepsiniGetirDal(x => x.SepetId == id);
        }

        public List<UrunSepet> UrunSepetGetir(string p,int id)
        {
            return _urun.UrunSepetGetirDal(p,x=>x.SepetId == id);
        }
    }
}
