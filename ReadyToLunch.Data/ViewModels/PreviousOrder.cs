using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Data.ViewModels
{
    public class PreviousOrder
    {
        public int OrderID { get; set; }
        public string DishName { get; set; }
        public string RestaurantName { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
