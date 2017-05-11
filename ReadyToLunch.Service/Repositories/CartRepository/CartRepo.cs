using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories.CartRepository
{
    public class CartRepo : GenericRepo<CartItem>, IDisposable, ICartRepo
    {
        //private readonly LunchContext _context;
        //private readonly DbSet<CartItem> _table;
        private bool _disposed = false;

        //public CartRepo()
        //{

        //}

        //public CartRepo(LunchContext context, DbSet<CartItem> table) : base(context, table)
        //{
        //    _context = context;
        //    _table = table;
        //}

        public CartRepo(LunchContext context) : base(context)
        {
            //_context = context;
            //_table = context.Cart;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                    //_table.Dispose(); what shall be disposed here? what is unmanaged resource? 
                }
            }
            this._disposed = true;
        }

        public CartItem GetByName(string name)
        {
            return _context.Cart.FirstOrDefault(ci => ci.Dish.DishName == name);
        }

        public void AddToCart(CartItem entity)
        {
            var cartItemInDatabase = CartItemInDatabase(entity);
            if (cartItemInDatabase == null)
            {
                entity.DishAmount = 1;
                entity.TotalPrice = _context.Dishes.Where(d => d.DishID == entity.DishID).Select(d => d.Price).Single() * entity.DishAmount;
                _context.Cart.Add(entity);
            }
            else
            {
                cartItemInDatabase.DishAmount += 1;
                cartItemInDatabase.TotalPrice = _context.Dishes.Where(d => d.DishID == entity.DishID)
                                                                .Select(d => d.Price).Single() * cartItemInDatabase.DishAmount;
            }
            _context.SaveChanges();
        }

        public void MinFromCart(CartItem entity)
        {
            var cartItemInDatabase = CartItemInDatabase(entity);
            if (cartItemInDatabase.DishAmount == 1)
            {
                _context.Cart.Remove(cartItemInDatabase);
            }
            else
            {
                cartItemInDatabase.DishAmount -= 1;
                cartItemInDatabase.TotalPrice = _context.Dishes.Where(d => d.DishID == entity.DishID)
                                                                .Select(d => d.Price).Single() * cartItemInDatabase.DishAmount;
            }
            _context.SaveChanges();
        }

        public void CancelFromCart(CartItem entity)
        {
            var cartItemInDatabase = CartItemInDatabase(entity);
            _context.Cart.Remove(cartItemInDatabase);
            _context.SaveChanges();
        }

        public CartItem CartItemInDatabase(CartItem entity)
        {
            var cartItemInDatabase = _context.Cart.Where(ci => ci.DishID == entity.DishID
                                                        && ci.CustomerID == entity.CustomerID
                                                        && ci.RestaurantID == entity.RestaurantID).FirstOrDefault();
            return cartItemInDatabase;
        }
    }
}
