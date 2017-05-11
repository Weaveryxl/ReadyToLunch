using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReadyToLunch.Model.Models
{
    public class Customer : User
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}