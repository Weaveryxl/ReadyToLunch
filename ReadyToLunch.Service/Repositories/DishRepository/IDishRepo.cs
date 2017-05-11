using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.DishRepository
{
    public interface IDishRepo : IRepository<Dish>
    {
        // Get Dish By Name
        Dish GetByName(string name); 
    }
}
