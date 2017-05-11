using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.CartServices
{
    public interface ICartService
    {
        // Get CartItem by name
        CartItem GetByName(string name);
        void AddToCart(CartItem entity);
        void MinFromCart(CartItem entity);
        void CancelFromCart(CartItem entity);
    }
}
