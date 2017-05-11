using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories
{
    public interface IRestaurantRepo : IRepository<Restaurant>
    {
        // get the restaurant but string name
        Restaurant GetByName(string name);
    }
}
