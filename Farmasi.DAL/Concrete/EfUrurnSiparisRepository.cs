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
    public class EfUrunSiparisRepository : EfGenericepository<SiparisUrun>, IUrunSiparisRepository
    {
        FarmasiDB c = new FarmasiDB();

        DbSet<SiparisUrun> _object;

        public EfUrunSiparisRepository()
        {
            _object = c.Set<SiparisUrun>();
        }
        public List<SiparisUrun> UrunSiparisGetirDal(string p, Expression<Func<SiparisUrun, bool>> filter)
        {
            return c.SiparisUruns.Where(filter).Include(p).ToList();
        }
    }
}
