using BookStore.DAL.Entities;
using System.Data.Entity;

namespace BookStore.DAL.EF
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BookContext(string connectionString) : base(connectionString)
        {

        }
        public BookContext():base()
        {

        }

    }
}
