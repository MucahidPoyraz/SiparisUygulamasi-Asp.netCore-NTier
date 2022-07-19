using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmasi.BL.Concrete
{
    public class UrunSiparisService : GenericService<SiparisUrun>, IUrunSiparisService
    {
        private readonly IUrunSiparisRepository _urunsiparis;
        public UrunSiparisService(IGenericRepository<SiparisUrun> repository, IUrunSiparisRepository urunsiparis) : base(repository)
        {
            _urunsiparis = urunsiparis;
        }
        public List<SiparisUrun> UrunSiparisGetir(string p, int id)
        {
            return _urunsiparis.UrunSiparisGetirDal(p, x => x.SiparisId == id);
        }

       
    }
}
