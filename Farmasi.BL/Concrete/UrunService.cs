using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Concrete
{
    public class UrunService : GenericService<Urun>, IUrunService
    {
        private readonly IGenericRepository<Urun> _urun;
        public UrunService(IGenericRepository<Urun> repository, IGenericRepository<Urun> urun) : base(repository)
        {
            _urun = urun;
        }

        public List<Urun> UrunGetir(int id)
        {
            return _urun.HepsiniGetirDal(x=>x.KategoriTwoId==id);
        }
    }
}
