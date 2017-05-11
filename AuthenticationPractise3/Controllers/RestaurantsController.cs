using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadyToLunch.Data;
using ReadyToLunch.Service.Services.RestaurantServices;
using ReadyToLunch.Model.Models;
using ReadyToLunch.Data.ViewModels;
using ReadyToLunch.Service.Repositories;
using ReadyToLunch.Service.Services.CartServices;

namespace AuthenticationPractise3.Controllers
{
    public class RestaurantsController : Controller
    {
        private LunchContext db = new LunchContext();
        //private readonly IRestaurantRepo _RestaurantRepo;
        private readonly IRestaurantService _RestaurantService;
        private readonly ICartService _CartService;

        public RestaurantsController()
        {

        }

        public RestaurantsController(IRestaurantService restaurantService, ICartService cartService)
        {
            _RestaurantService = restaurantService;
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
                    var cartItem = new CartItem();
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
            Restaurant restaurant = db.Restaurants.Find(id);
            //Restaurant restaurant = _RestaurantService.GetByID(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,RestaurantDescrip,CategoryID,Stars,ID,Email,FirstName,LastName,Password,Address1,Address2,Address3,State,RegisterDate,Roles,isActived,VIP,FullAddress")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _RestaurantService.Create(restaurant);
                //db.Restaurants.Add(restaurant);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", restaurant.CategoryID);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Restaurant restaurant = db.Restaurants.Find(id);
            Restaurant restaurant = _RestaurantService.GetByID(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", restaurant.CategoryID);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,RestaurantDescrip,CategoryID,Stars,ID,Email,FirstName,LastName,Password,Address1,Address2,Address3,State,RegisterDate,Roles,isActived,VIP,FullAddress")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", restaurant.CategoryID);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            var viewModel = new RestaurantIndexData();
            var user = this.HttpContext.User; // Here is the key!!, don't pass it in, directaly get it!!
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            viewModel.Restaurants = db.Restaurants.Where(c => c.Email == user.Identity.Name);

            viewModel.Dishes = viewModel.Restaurants.Single().Dishes;
            return View(viewModel);
        }

        [Authorize(Roles = "Restaurant")]
        public ActionResult OrdersToGo()
        {
            var OrdersToGo = new List<Order>();
            OrdersToGo = db.Orders
                .Include(o => o.Customer)
                .Include(o => o.Cart)
                .Where(o => o.Cart.Any(c => c.Restaurant.Email == this.HttpContext.User.Identity.Name) )
                //.Where(o => o.Shipped == false)
                .OrderBy(o => o.Shipped)
                .ThenByDescending(o => o.OrderDate)
                .ToList();
            return View(OrdersToGo);
        }

        [Authorize(Roles = "Restaurant")]
        public ActionResult MyRestaurant()
        {
            var viewModel = new RestaurantIndexData();
            var user = this.HttpContext.User; // Here is the key!!, don't pass it in, directaly get it!!
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            viewModel.Restaurants = db.Restaurants.Where(c => c.Email == user.Identity.Name);

            viewModel.Dishes = viewModel.Restaurants.Single().Dishes;
            return View(viewModel);
        }
    }
}
