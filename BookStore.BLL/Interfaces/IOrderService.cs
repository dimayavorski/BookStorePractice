using BookStore.BLL.DTO;
using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Interface
{
    public interface IOrderService
    {
        BookDTO GetBook(int? id);
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<CategoryDTO> GetCategories();
        void Dispose();
    }
}
