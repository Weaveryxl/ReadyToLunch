using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Data.ViewModels
{
    public class OrderCartViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<CartItemBase> CartItems { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
