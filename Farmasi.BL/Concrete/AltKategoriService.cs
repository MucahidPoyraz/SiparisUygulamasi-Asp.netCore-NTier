using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Farmasi.BL.Concrete
{
    public class AltKategoriService : GenericService<KategoriTwo>, IAltKategoriService
    {
        private readonly IGenericRepository<KategoriTwo> _two;
        public AltKategoriService(IGenericRepository<KategoriTwo> repository, IGenericRepository<KategoriTwo> two) : base(repository)
        {
            _two = two;
        }
        public List<KategoriTwo> AltKAtegoriGetir(int id)
        {
           return _two.HepsiniGetirDal(x=>x.KategoriOneId == id);
        }
    }
}
