using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        public string DishName { get; set; }
        public string DishDisc { get; set; }
        public int Spicy { get; set; }
        public bool isMuslim { get; set; }
        public bool isGlutenFree { get; set; }
        public double Price { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        [ForeignKey("Cart")]
        public int CartID { get; set; }

        public virtual Category Category { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Restaurant> Restraurants { get; set; }
        public virtual ICollection<CartItem> Cart { get; set; }
    }
}