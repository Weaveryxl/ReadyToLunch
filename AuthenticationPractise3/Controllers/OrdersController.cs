using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using ReadyToLunch.Data.ViewModels;
using ReadyToLunch.Service.Services.CartServices;
using ReadyToLunch.Service.Services.OrderServices;

namespace AuthenticationPractise3.Controllers
{
    public class OrdersController : Controller
    {
        private LunchContext db = new LunchContext();
        private readonly ICartService _CartService;
        private readonly IOrderService _OrderService;

        public OrdersController(IOrderService orderService, ICartService cartService)
        {
            _CartService = cartService;
            _OrderService = orderService;
        }

        // GET: Orders
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

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Email");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderID,CustomerID,DishID,CartID,OrderDate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Orders.Add(order);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Email", order.CustomerID);
        //    return View(order);
        //}

        // GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Email", order.CustomerID);
        //    return View(order);
        //}

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrderID,CustomerID,DishID,CartID,OrderDate")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(order).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Email", order.CustomerID);
        //    return View(order);
        //}

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PlaceOrder()
        {
            //Order order = new Order();
            //order.Customer = db.Customers.Where(c => c.Email == HttpContext.User.Identity.Name).FirstOrDefault();
            //order.Dishes = db.Cart.;
            if (ModelState.IsValid)
            {
                Order order = new Order();
                order.Cart = new List<CartItemBase>();
                double total = 0;
                if (db.Cart.Count() == 0)
                {
                    return RedirectToAction("Cart", "Orders");
                }

                foreach (var cartItem in db.Cart)
                {
                    //order.CustomerID = db.Customers.Where(c => c.Email == HttpContext.User.Identity.Name).Select(c => c.ID).FirstOrDefault();
                    //order.DishID = cartItem.DishID;
                    //order.CartID = cartItem.ID;
                    CartItemBase cartItemBase = new CartItemBase();
                    cartItemBase.CustomerID = cartItem.CustomerID;
                    cartItemBase.RestaurantID = cartItem.RestaurantID;
                    cartItemBase.DishID = cartItem.DishID;
                    cartItemBase.DishAmount = cartItem.DishAmount;
                    cartItemBase.TotalPrice = cartItem.TotalPrice;

                    order.Cart.Add(cartItemBase);

                    total += cartItem.TotalPrice;
                    //order.number = cartItem.DishAmount;
                }
                //db.SaveChanges();
                order.CustomerID = order.Cart.Select(c => c.CustomerID).First();
                order.OrderDate = DateTime.Now;
                order.TotalPrice = total;
                //_OrderService.AddToRecord(order);
                db.Orders.Add(order);
                db.Cart.RemoveRange(db.Cart);
                db.SaveChanges();
            }
            return RedirectToAction("Cart");
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Cart()
        {
            //var viewModel = new RestaurantIndexData();
            var cart = new List<CartItem>();

            if (ModelState.IsValid)
            {
                var user = this.HttpContext.User;
                var customer = db.Customers.Where(c => c.Email == user.Identity.Name).FirstOrDefault();
                cart = db.Cart.Where(c => c.CustomerID == customer.ID).ToList();
            } 
            return View(cart);
        }
    }
}
