using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Concrete
{
    public class SiparisService : GenericService<Siparis>, ISiparisService
    {
        private readonly IGenericRepository<Siparis> _siparis;
        public SiparisService(IGenericRepository<Siparis> repository, IGenericRepository<Siparis> siparis) : base(repository)
        {
            _siparis = siparis;
        }

        public List<Siparis> SiparisGetir(int id)
        {
            return _siparis.HepsiniGetirDal(x => x.SesionId == id);
        }
        //public Siparis SiparisGetir(int id)
        //{
        //    
        //}
    }
}
