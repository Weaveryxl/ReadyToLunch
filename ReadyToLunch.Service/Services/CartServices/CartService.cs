using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Repositories.CartRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.CartServices
{
    public class CartService : GenericService<CartItem>, ICartService
    {
        private readonly ICartRepo _Repo;

        public CartService(ICartRepo Repo) : base(Repo)
        {
            _Repo = Repo;
        }

        public void AddToCart(CartItem entity)
        {
            _Repo.AddToCart(entity);
        }

        public void CancelFromCart(CartItem entity)
        {
            _Repo.CancelFromCart(entity);
        }

        public CartItem GetByName(string name)
        {
            return _Repo.GetByName(name);
        }

        public void MinFromCart(CartItem entity)
        {
            _Repo.MinFromCart(entity);
        }
    }
}
