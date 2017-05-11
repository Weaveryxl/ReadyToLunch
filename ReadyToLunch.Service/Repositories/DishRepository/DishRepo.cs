using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.DishRepository
{
    public class DishRepo : GenericRepo<Dish>, IDishRepo, IDisposable
    {
        //private readonly LunchContext _context;
        //private readonly DbSet<Dish> _table;
        private bool _disposed = false;

        //public DishRepo(LunchContext context, DbSet<Dish> table) : base(context, table)
        //{
        //    _context = context;
        //    _table = table;
        //}

        public DishRepo(LunchContext context) : base(context)
        {
            //_context = context;
            //_table = context.Dishes;
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

        public Dish GetByName(string name)
        {
            return _context.Dishes.FirstOrDefault(d => d.DishName == name);
        }
    }
}
