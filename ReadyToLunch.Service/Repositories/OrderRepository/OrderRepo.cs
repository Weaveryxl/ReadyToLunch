using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.OrderRepository
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo, IDisposable
    {
        private bool _disposed = false;

        public OrderRepo(LunchContext context) : base(context)
        {
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


        public void AddToRecord(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}
