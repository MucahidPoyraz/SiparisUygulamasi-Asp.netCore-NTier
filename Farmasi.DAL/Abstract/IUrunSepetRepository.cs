using Farmasi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Farmasi.DAL.Abstract
{
    public interface IUrunSepetRepository : IGenericRepository<UrunSepet>
    {
        List<UrunSepet> UrunSepetGetirDal(string p, Expression<Func<UrunSepet, bool>> filter);
    }
}
