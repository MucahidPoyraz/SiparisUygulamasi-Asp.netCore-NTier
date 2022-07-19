using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Farmasi.DAL.Abstract
{
    public interface IUrunSiparisRepository : IGenericRepository<SiparisUrun>
    {
        List<SiparisUrun> UrunSiparisGetirDal(string p, Expression<Func<SiparisUrun, bool>> filter);
    }
}
