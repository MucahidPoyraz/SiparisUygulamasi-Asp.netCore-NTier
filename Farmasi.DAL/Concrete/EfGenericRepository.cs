using Farmasi.DAL.Abstract;
using Farmasi.DAL.Context;
using Farmasi.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Farmasi.DAL.Concrete
{
    public class EfGenericepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        FarmasiDB c = new FarmasiDB();
       
        DbSet<T> _object;

        public EfGenericepository()
        {
            _object = c.Set<T>();
        }


        public void SilDal(T p)
        {
            var silinecek = c.Entry(p);
            silinecek.State = EntityState.Deleted;
            c.SaveChanges();
            
        }

        public void EkleDal(T p)
        {
            var eklenecek = c.Add(p);
            eklenecek.State = EntityState.Added;
            c.SaveChanges();
        }

        public T GetirDal(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void GuncelleDal(T p)
        {
            var guncellenecek = c.Entry(p);
            guncellenecek.State = EntityState.Modified;
            c.SaveChanges();
        }

        public List<T> HepsiniGetirDal()
        {
            return _object.ToList();
        }

        public List<T> HepsiniGetirDal(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T IdileGetirDal(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> BaglıTablolarIleGetirDal(string p)
        {
            return _object.Include(p).ToList();
        }

        public Task<List<T>> HepsiniGetirDal<TKey>(string p,Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector, OrdeyByType ordeyByType = OrdeyByType.DESC)
        {
            return ordeyByType == OrdeyByType.ASC
                ? _object.Include(p).Where(filter).OrderBy(selector).ToListAsync()
                : _object.Include(p).Where(filter).OrderByDescending(selector).ToListAsync();
        }
    }
}
