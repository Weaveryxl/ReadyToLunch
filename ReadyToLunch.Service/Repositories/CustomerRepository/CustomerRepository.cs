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
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo, IDisposable
    {
        //private readonly LunchContext _context;
        //private readonly DbSet<Customer> _table;
        private bool _disposed = false;

        //public CustomerRepo(LunchContext context, DbSet<Customer> table) : base(context, table)
        //{
        //    _context = context;
        //    _table = table;
        //}

        public CustomerRepo(LunchContext context) : base(context)
        {
            //_context = context;
            //_table = context.Customers;
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

        public Customer GetByName(string name)
        {
            return _context.Customers.FirstOrDefault(c => c.UserName == name);
        }
    }
}
