using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface ICartRepository
    {
        Task AddToCart(Book book,string Id);
        Task<List<CartItem>> GetAll(string Id);

    }
}
