using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Security.Claims;
using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Services.RestaurantServices;
using ReadyToLunch.Service.Services.CartServices;
using ReadyToLunch.Data.ViewModels;
using ReadyToLunch.Service.Services.CustomerServices;

namespace AuthenticationPractise3.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CustomersController : Controller
    {
        private LunchContext db = new LunchContext();
        //private readonly IRestaurantRepo _RestaurantRepo;
        private readonly ICustomerService  _CustomerService;
        private readonly ICartService _CartService;

        //public CustomersController()
        //{

        //}

        public CustomersController(ICustomerService customerService, ICartService cartService)
        {
            _CustomerService = customerService;
            _CartService = cartService;
        }

        // GET: Restaurants
        public ActionResult Index(int? id, int? DishID, int? changeNumber)
        {
            var viewModel = new RestaurantIndexData();
            viewModel.Restaurants = db.Restaurants
                .Include(r => r.Category)
                .Include(r => r.Dishes.Select(d => d.Restraurants))
                .OrderBy(r => r.UserName);
            viewModel.Cart = db.Cart;

            if (id != null)
            {
                ViewBag.RestaurantID = id.Value;
                viewModel.Dishes = viewModel.Restaurants.Where(r => r.ID == id.Value).Single().Dishes;
            }

            if (DishID != null)
            {
                if (ModelState.IsValid)
                {
                    var cartItem = new CartItem(/*db.Dishes.Where(d => d.DishID == DishID).Single()*/);
                    var user = this.HttpContext.User;
                    var customer = db.Customers.Where(c => c.Email == user.Identity.Name).FirstOrDefault();
                    cartItem.CustomerID = customer.ID;
                    cartItem.DishID = DishID ?? default(int);
                    cartItem.RestaurantID = id ?? default(int);

                    if (changeNumber == 0)  //when adding, changeNumber == 0
                    {
                        _CartService.AddToCart(cartItem);
                    }
                    else if (changeNumber == 1)     //when removing, changeNumber == 1
                    {
                        _CartService.MinFromCart(cartItem);
                    }
                    else if (changeNumber == 2)     // When canceling, changeNumber == 2
                    {
                        _CartService.CancelFromCart(cartItem);
                    }
                }
                ViewBag.DishID = DishID.Value;
                viewModel.Cart = db.Cart;
            }
            return View(viewModel);
        }

        

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            //Restaurant restaurant = _RestaurantService.GetByID(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Personal_Profile()
        {
            var user = this.HttpContext.User; // Here is the key!!, don't pass it in, directaly get it!!
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = db.Customers.Where(c => c.Email == user.Identity.Name).FirstOrDefault();
            return View(customer);
        }

        public void UpdateCart(int RestaurantID, int DishID, int ChangeNumber)
        {
            if (ModelState.IsValid)
            {
                var cartItem = new CartItem(/*db.Dishes.Where(d => d.DishID == DishID).Single()*/);
                var user = this.HttpContext.User;
                var customer = db.Customers.Where(c => c.Email == user.Identity.Name).FirstOrDefault();
                cartItem.CustomerID = customer.ID;
                cartItem.DishID = DishID;
                cartItem.RestaurantID = RestaurantID;

                if (ChangeNumber == 0)  //when adding, changeNumber == 0
                {
                    _CartService.AddToCart(cartItem);
                }
                else if (ChangeNumber == 1)     //when removing, changeNumber == 1
                {
                    _CartService.MinFromCart(cartItem);
                }
                else if (ChangeNumber == 2)     // When canceling, changeNumber == 2
                {
                    _CartService.CancelFromCart(cartItem);
                }

                if(db.Cart.Count() == 0) // this part doesn't work, why?
                {
                    RedirectToAction("Cart", "Orders");
                }
            }
        }

        [Authorize(Roles = "Customer")]
        public ActionResult PrevOrders()
        {
            //var viewModels = new List<PreviousOrder>();

            //var CartItems = db.CartItemBases
            //    .Include(cib => cib.Customer)
            //    .Where(cib => cib.Customer.Email == this.HttpContext.User.Identity.Name)
            //    .Include(cib => cib.Dish)
            //    .Include(cib => cib.Restaurant)
            //    .ToList();
            //for (int i = 0; i < CartItems.Count(); i++)
            //{
            //    var viewModel = new PreviousOrder();
            //    viewModel.OrderID = CartItems[i].OrderID;
            //    viewModel.DishName = CartItems[i].Dish.DishName;
            //    viewModel.RestaurantName = CartItems[i].Restaurant.UserName;
            //    viewModel.Quantity = CartItems[i].DishAmount;
            //    viewModel.TotalPrice = CartItems[i].TotalPrice;
            //    viewModel.OrderDate = CartItems[i].Order.OrderDate;
            //    viewModels.Add(viewModel);
            //}

            //return View(viewModels.OrderBy(v => v.OrderDate).ToList());
            var orders = new List<Order>();
            orders = db.Orders
                .Include(o => o.Customer)
                .Where(o => o.Customer.Email == this.HttpContext.User.Identity.Name)
                .Include(o => o.Cart)
                .OrderByDescending(o => o.OrderDate)
                .ToList();

            var viewModel = new OrderCartViewModel();
            //viewModel.Restaurants = db.Restaurants;
            //viewModel.Dishes = db.Dishes;
            viewModel.CartItems = db.CartItemBases
                .Include(cib => cib.Customer)
                .Where(cib => cib.Customer.Email == this.HttpContext.User.Identity.Name)
                .ToList();
            //viewModel.Customers = db.Customers;
            viewModel.Orders = orders;

            return View(viewModel);
        }
    }
}
