using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.OrderServices
{
    public interface IOrderService
    {
        //Get record By name
        void AddToRecord(Order order);
    }
}
