using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class CartItem
    {
        //public CartItem()
        //{
        //    TotalPrice = Dish.Price * DishAmount;
        //}

        //public CartItem(Dish dish)
        //{
        //    TotalPrice = dish.Price * DishAmount;
        //}

        [Key]
        public int ID { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }

        [ForeignKey("Dish")]
        public int DishID { get; set; }
        public int DishAmount { get; set; }

        public double TotalPrice { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
    }
}