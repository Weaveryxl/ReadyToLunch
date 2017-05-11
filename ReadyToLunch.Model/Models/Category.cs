using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}