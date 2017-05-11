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
    public class RestaurantRepository : IRepository<Restaurant>, IDisposable
    {
        private readonly LunchContext _context;
        private bool _disposed = false;

        public RestaurantRepository(LunchContext context)
        {
            _context = context;
        }

        public void Add(Restaurant entity)
        {
            _context.Restaurants.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Restaurant entity)
        {
            _context.Restaurants.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Expression<Func<Restaurant, bool>> where)
        {
            IEnumerable<Restaurant> objects = _context.Restaurants.Where<Restaurant>(where).AsEnumerable();
            foreach (Restaurant obj in objects)
            {
                _context.Restaurants.Remove(obj);
            }
            _context.SaveChanges();
        }

        public void Delete(Restaurant entity)
        {
            _context.Restaurants.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // what is GC?
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

        public Restaurant Get(Expression<Func<Restaurant, bool>> where) // why shall I add a @ mark before where?
        {
            return _context.Restaurants.Where(where).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetByID(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant GetByName(string name)
        {
            return _context.Restaurants.Where(r => r.UserName == name).FirstOrDefault();
        }

        public IEnumerable<Restaurant> GetMany(Expression<Func<Restaurant, bool>> where)
        {
            return _context.Restaurants.Where(where).ToList();
        }
    }
}