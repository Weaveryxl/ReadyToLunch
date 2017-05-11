using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories
{
    public class RestaurantRepo : GenericRepo<Restaurant> , IRestaurantRepo, IDisposable
    {
        //private readonly LunchContext _context;
        //private readonly DbSet<Restaurant> _table;
        private bool _disposed = false;

        //public RestaurantRepo()
        //{

        //}

        //public RestaurantRepo(LunchContext context, DbSet<Restaurant> table) : base(context, table)
        //{
        //    _context = context;
        //    _table = table;
        //}

        public RestaurantRepo(LunchContext context) : base(context)
        {
            
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Restaurant GetByName(string name)
        {
            return _context.Restaurants.FirstOrDefault(r => r.UserName == name);
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
    }
}
