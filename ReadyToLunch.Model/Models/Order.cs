using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }

        [Key]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public bool Shipped { get; set; }

        public bool Delivered { get; set; }

        [JsonIgnore]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartItemBase> Cart { get; set; }
    }
}