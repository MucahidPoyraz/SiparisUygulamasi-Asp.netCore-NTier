using Farmasi.BL.Abstract;
using Farmasi.DAL.Abstract;
using Farmasi.Entities.Abstract;
using System.Collections.Generic;

namespace Farmasi.BL.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class,IEntity,new()
    {
        private readonly IGenericRepository<T> _repository;
       

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
            
        }

        public void EkleBl(T p)
        {
           
                _repository.EkleDal(p);
            
           
        }

        public void GuncelleBl(T p)
        {
          
                _repository.GuncelleDal(p);
            
           
        }

        public List<T> HepsiniGetirBl()
        {
            return _repository.HepsiniGetirDal();
        }

       

        public List<T> HepsiniGetirBl(string p)
        {
            return _repository.BaglıTablolarIleGetirDal(p);
        }

    

        public T IdileGetirBl(int id)
        {
            return _repository.IdileGetirDal(x => x.ID == id);
        }

        

        public void SilBl(int id)
        {
            
            var silinecek = IdileGetirBl(id);
            _repository.SilDal(silinecek);
        }
    }
}
