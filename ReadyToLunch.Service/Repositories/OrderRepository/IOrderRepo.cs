using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.OrderRepository
{
    public interface IOrderRepo : IRepository<Order>
    {
        void AddToRecord(Order order);
    }
}
