using ReadyToLunch.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services
{
    public abstract class GenericService<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _GenericRepo;

        public GenericService(IRepository<T> GenericRepo)
        {
            _GenericRepo = GenericRepo;
        }

        public void Create(T entity)
        {
            _GenericRepo.Add(entity);
        }

        public void Delete(T entity)
        {
            _GenericRepo.Delete(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null)
        {
            var res = where == null
                ? _GenericRepo.GetAll()
                : _GenericRepo.GetAll().AsQueryable().Where(where);
            return res;
        }

        public T GetByID(int? id)
        {
            return _GenericRepo.GetByID(id);
        }

        //public T GetByName(Expression<Func<T, bool>> where)
        //{
        //    return _GenericRepo.GetByName(where);
        //}
    }
}
