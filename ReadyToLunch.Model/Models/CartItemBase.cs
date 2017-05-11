using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Model.Models
{
    public class CartItemBase
    {
        public int CartItemBaseID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        [ForeignKey("Dish")]
        public int DishID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }

        public int DishAmount { get; set; }

        public double TotalPrice { get; set; }
        [JsonIgnore]
        public virtual Dish Dish { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }
    }
}
