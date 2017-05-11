using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class Restaurant : User
    {
        [Required]
        [StringLength(50, ErrorMessage = "User name cannot be longer than 50 characters")]
        [Display(Name = "Restaurant Name")]
        public override string UserName { get; set; }

        public string RestaurantDescrip { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public double Stars { get; set; }

        public string Website { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Dish>  { get; set; }
    }
}