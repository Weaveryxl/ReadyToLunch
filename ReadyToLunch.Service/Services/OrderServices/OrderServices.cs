using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Repositories.OrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.OrderServices
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderRepo _OrderRepo;

        public OrderService(IOrderRepo Repo) : base(Repo)
        {
            _OrderRepo = Repo;
        }

        public void AddToRecord(Order order)
        {
            _OrderRepo.AddToRecord(order);
        }
    }
}
