using BookStore.BLL.DTO;
using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.BLL.ShoppinCart;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Interface
{
    public interface IOrderService
    {
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBooks(string category);
        IEnumerable<CategoryDTO> GetCategories();
        Cart GetCart();
        void Dispose();
    }
}
