using BookStore.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace BookStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Category> Categories { get; }
        ICartRepository Carts { get; }
        void Save();
        Task SaveAsync();
    }
}
