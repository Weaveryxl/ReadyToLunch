using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Data.ViewModels
{
    public class RestaurantIndexData
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<CartItem> Cart { get; set; }
    }
}