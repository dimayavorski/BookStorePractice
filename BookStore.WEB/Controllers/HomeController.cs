using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using BookStore.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService service)
        {
            orderService = service;
        }
        public ActionResult Index()
        {
            IEnumerable<BookDTO> bookDtos = orderService.GetBooks();
            return View(bookDtos);
        }
        public ActionResult GetBook(int id)
        {
            var book = orderService.GetBook(id);
            return View(book);
        }


    }
}