using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ReadyToLunch.Data;
using ReadyToLunch.Model.Models;
using Microsoft.AspNet.Identity;
using ReadyToLunch.Data.ViewModels;

namespace AuthenticationPractise3.Controllers
{
    public class OrdersRecordController : ApiController
    {
        private LunchContext db = new LunchContext();

        // GET: api/OrdersRecord
        //public IQueryable<Order> GetOrders()
        //{
        //    return db.Orders;
        //}

        // GET: api/OrdersRecord/GetDishesOrderID
        //[Route("GetDishesOrderID/{id}")]
        [ResponseType(typeof(List<CartItemBase>))]
        [Route("api/OrdersRecord/GetDishesOrderID/{id}")]
        public List<PreviousOrder> GetDishesOrderID(int ID)
        {
            var viewModels = new List<PreviousOrder>();

            var CartItems = db.CartItemBases
                .Where(cib => cib.OrderID == ID)
                .Include(cib => cib.Dish)
                .Include(cib => cib.Restaurant)
                .ToList();
            for (int i = 0; i < CartItems.Count(); i++)
            {
                var viewModel = new PreviousOrder();
                viewModel.OrderID = CartItems[i].OrderID;
                viewModel.DishName = CartItems[i].Dish.DishName;
                viewModel.RestaurantName = CartItems[i].Restaurant.UserName;
                viewModel.Quantity = CartItems[i].DishAmount;
                viewModel.TotalPrice = CartItems[i].TotalPrice;
                viewModel.OrderDate = CartItems[i].Order.OrderDate;
                viewModels.Add(viewModel);
            }
            //var Dishes = db.CartItemBases
            //    .Where(cib => cib.OrderID == ID)
            //    .Include(cib => cib.Restaurant)
            //    .Include(cib => cib.Dish)
            //    .ToList();
            //Dishes.FirstOrDefault().Restaurant.UserName
            return viewModels.OrderBy(v => v.OrderDate).ToList();
        }

        //// GET: api/OrdersRecord/5
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult GetOrder(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(order);
        //}

        [HttpPost]
        [Route("api/OrdersRecord/OrderShipped/{id}")]
        public void OrderShipped(int OrderID, bool Checked)
        {
            db.Orders
                .Where(o => o.OrderID == OrderID)
                .Single().Shipped = Checked;
            db.SaveChanges();
        }


        //// PUT: api/OrdersRecord/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutOrder(int id, Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != order.OrderID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/OrdersRecord
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult PostOrder(Order order)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Orders.Add(order);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = order.OrderID }, order);
        //}

        //// DELETE: api/OrdersRecord/5
        //[ResponseType(typeof(Order))]
        //public IHttpActionResult DeleteOrder(int id)
        //{
        //    Order order = db.Orders.Find(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Orders.Remove(order);
        //    db.SaveChanges();

        //    return Ok(order);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool OrderExists(int id)
        //{
        //    return db.Orders.Count(e => e.OrderID == id) > 0;
        //}
    }
}