using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.CartRepository
{
    public interface ICartRepo : IRepository<CartItem>
    {
        // Get cartItem by name
        CartItem GetByName(string name);

        void AddToCart(CartItem entity);

        void MinFromCart(CartItem entity);

        void CancelFromCart(CartItem entity);

        CartItem CartItemInDatabase(CartItem entity);
    }
}
