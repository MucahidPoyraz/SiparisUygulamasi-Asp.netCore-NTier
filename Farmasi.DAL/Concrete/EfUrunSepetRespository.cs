using Farmasi.DAL.Abstract;
using Farmasi.DAL.Context;
using Farmasi.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Farmasi.DAL.Concrete
{
    public class EfUrunSepetRespository : EfGenericepository<UrunSepet>, IUrunSepetRepository
    {
        FarmasiDB c = new FarmasiDB();

        DbSet<UrunSepet> _object;

        public EfUrunSepetRespository()
        {
            _object = c.Set<UrunSepet>();
        }
        public List<UrunSepet> UrunSepetGetirDal(string p, Expression<Func<UrunSepet, bool>> filter)
        {
            return c.UrunSepets.Where(filter).Include(p).ToList();
        }
    }
}
