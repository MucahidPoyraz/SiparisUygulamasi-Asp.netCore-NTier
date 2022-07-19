using Farmasi.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Farmasi.BL.Abstract
{
    public interface IGenericService<T> where T : class,IEntity,new()
    {
        List<T> HepsiniGetirBl();
        List<T> HepsiniGetirBl(string p);

        T IdileGetirBl(int id);

        void SilBl(int id);
        void GuncelleBl(T p);
        void EkleBl(T p);
    }
}
