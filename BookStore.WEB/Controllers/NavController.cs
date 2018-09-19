using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using BookStore.WEB.Models;

namespace BookStore.WEB.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        IOrderService orderService;
        public NavController(IOrderService service)
        {
            orderService = service;
        }
        public ActionResult GetNav(string category = null)
        {
            var categoryDTOs = orderService.GetCategories();
            ViewBag.SelectedCategegory = category;
            return PartialView(categoryDTOs);
        }
    }
}