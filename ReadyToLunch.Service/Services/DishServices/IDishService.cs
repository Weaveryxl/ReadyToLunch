using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.DishServices
{
    public interface IDishService
    {
        // Get Dish by name
        Dish GetByName(string name);
    }
}
