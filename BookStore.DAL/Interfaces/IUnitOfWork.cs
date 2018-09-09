using BookStore.DAL.Entities;
using System;

namespace BookStore.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Category> Categories { get; }
        void Save();
    }
}
