using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using BookStore.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        private readonly IOrderService orderSerivce;
        private readonly ShoppingCartFactory shoppingCartFactory;
        public CheckoutController(IOrderService service,ShoppingCartFactory factory)
        {
            shoppingCartFactory = factory;
            orderSerivce = service;
        } 
        public ActionResult  MakeOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> MakeOrder(FormCollection values)
        {
            var order = new OrderDTO();
            TryUpdateModel(order);
            order.OrderDate = DateTime.Now;
            var cart = shoppingCartFactory.GetCart(this.HttpContext);
            await orderSerivce.CreateNewOrder(order, cart.ShoppingCartId);


            return RedirectToAction("Complete",new { name =order.FirstName,lname = order.LastName });
        }
        public ActionResult Complete(string name,string lname)
        {
            ViewBag.name = name;
            ViewBag.lname = lname;
            return View();
        }
    }
}