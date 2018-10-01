using BookStore.DAL.EF;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BookContext db;
        public CartRepository(BookContext context)
        {
            db = context;
        }
        public async Task AddToCart(Book book,string Id)
        {
            var cartItem = await db.CartItems.SingleOrDefaultAsync(
                c => c.CartId == Id
                && c.BookId == book.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    BookId = book.Id,
                    CartId = Id,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
            
        }

        public Task<List<CartItem>> GetAll(string Id)
        {
            return db.CartItems.Where(c => c.CartId == Id).Include(b => b.Book).ToListAsync();
        }

     
    }
}
