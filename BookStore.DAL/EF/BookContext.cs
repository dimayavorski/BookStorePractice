using BookStore.DAL.Entities;
using System.Data.Entity;

namespace BookStore.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookContext(string connectionString) : base(connectionString)
        {

        }

    }
}
