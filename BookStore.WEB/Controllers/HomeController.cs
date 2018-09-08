using BookStore.BLL.DTO;
using BookStore.BLL.Interface;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace BookStore.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService service)
        {
            orderService = service;
        }
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            IEnumerable<BookDTO> bookDtos = orderService.GetBooks();
            return View(bookDtos.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult GetBook(int id)
        {
            var book = orderService.GetBook(id);
            return View(book);
        }


    }
}