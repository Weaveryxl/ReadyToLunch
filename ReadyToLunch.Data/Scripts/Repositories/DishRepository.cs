using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;

namespace AuthenticationPractise3.Repositories
{
    public class DishRepository : IRepository<Dish>, IDisposable
    {
        private readonly LunchContext _context;
        private bool _disposed = false;

        public DishRepository(LunchContext context)
        {
            _context = context;
        }

        public void Add(Dish entity)
        {
            _context.Dishes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<Dish, bool>> where)
        {
            IEnumerable<Dish> objects = _context.Dishes.Where<Dish>(where).AsEnumerable();
            foreach (Dish obj in objects)
            {
                _context.Dishes.Remove(obj);
            }
            _context.SaveChanges();
        }

        public void Delete(Dish entity)
        {
            _context.Dishes.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public Dish Get(Expression<Func<Dish, bool>> where)
        {
            return _context.Dishes.Where(where).FirstOrDefault();
        }

        public IEnumerable<Dish> GetAll()
        {
            return _context.Dishes.ToList();
        }

        public Dish GetByID(int id)
        {
            return _context.Dishes.Find(id);
        }

        public Dish GetByName(string name)
        {
            return _context.Dishes.Where(d => d.DishName == name).FirstOrDefault();
        }

        public IEnumerable<Dish> GetMany(Expression<Func<Dish, bool>> where)
        {
            return _context.Dishes.Where(where).ToList();
        }

        public void Update(Dish entity)
        {
            _context.Dishes.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}