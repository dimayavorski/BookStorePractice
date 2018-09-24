using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using AutoMapper;
using BookStore.WEB.Models;

namespace BookStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService service)
        {
            orderService = service;
        }
        public ActionResult Index(string category,int? page = 1)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.category = category;
            ViewBag.page = page;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(orderService.GetBooks(category));
            return View(books.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult GetBook(int id)
        {
            var book = orderService.GetBook(id);
            return View(book);
        }


    }
}