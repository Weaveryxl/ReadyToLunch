using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.RestaurantServices
{
    public interface IRestaurantService : IService<Restaurant>
    {
        //Get record By name
        Restaurant GetByName(string name);
    }
}
