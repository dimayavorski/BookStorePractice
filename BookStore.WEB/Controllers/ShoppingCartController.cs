using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.BLL.DTO;
using System.Web.Mvc;
using BookStore.BLL.Interface;
using System.Threading.Tasks;
using BookStore.WEB.Models;

namespace BookStore.WEB.Controllers
{
    public class ShoppingCartController : Controller
    {
       
        IOrderService orderService;
        private readonly ShoppingCartFactory shoppingCartFactory;
        public ShoppingCartController(IOrderService service,ShoppingCartFactory factory)
        {
            orderService = service;
            shoppingCartFactory = factory;
        }
        public async Task<ActionResult> Index(string returnUrl)
        {
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel
            {
                CartItems = await orderService.GetAllCartItems(shoppingCartFactory.GetCart(this.HttpContext).ShoppingCartId),
                returnUrl = returnUrl
            };
            return View(viewModel);
        }
        //public async Task<ActionResult> ShowCart(string returnUrl)
        //{

        //    ShoppingCartViewModel viewModel = new ShoppingCartViewModel {
        //        CartItems = await orderService.GetAllCartItems(shoppingCartFactory.GetCart(this.HttpContext).ShoppingCartId),
        //        returnUrl = returnUrl
        //    };

        //    return PartialView("ShowCart", viewModel);

        //}
      
        public async Task<ActionResult> AddToCart(int? id, int? page, string category)
        {
            var addedBook = orderService.GetBook(id.Value);
            var cart = shoppingCartFactory.GetCart(this.HttpContext);
            await orderService.AddToCart(addedBook,cart.ShoppingCartId);
            
            return RedirectToAction("Index","Home", new { page = page.Value, category = category });
        } 


        public ActionResult RemoveFromCart(int id,string returnUrl)
        {
            
            return RedirectToAction("Index","ShoppingCart",new { returnUrl = returnUrl });
        }
        
       

    }
}