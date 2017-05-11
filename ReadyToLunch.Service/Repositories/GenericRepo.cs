using ReadyToLunch.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories
{
    public abstract class GenericRepo<T> : IRepository<T> where T : class
    {
        protected LunchContext _context;
        protected readonly IDbSet<T> _table;

        //public GenericRepo()
        //{

        //}

        protected GenericRepo(LunchContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _table.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                _table.Remove(obj);
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _table.Where(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int? id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _table.Where(where).ToList();
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
