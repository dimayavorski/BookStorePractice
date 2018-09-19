using AutoMapper;
using BookStore.BLL.DTO;
using BookStore.BLL.Infrastructure;
using BookStore.BLL.Interface;
using BookStore.DAL.Entities;
using BookStore.DAL.Interfaces;
using BookStore.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }
        public OrderService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        //Start of BookService logics
        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var book = Database.Books.Get(id.Value);
            if (book == null)
                throw new ValidationException("Книга не найдена", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<Book, BookDTO>(Database.Books.Get(id.Value));

        }

        public IEnumerable<BookDTO> GetBooks(string category)
        {
            IEnumerable<Book> books;
            if(category != null)
            {
                 books = Database.Books.GetAll().Where(b => b.Category.CategoryName == null || b.Category.CategoryName == category);
                
            }
            else
            {
                 books = Database.Books.GetAll();

            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Author,
          src => src.MapFrom(b => b.Author.Name)).ForMember(dto => dto.Category,
          src => src.MapFrom(b => b.Category.CategoryName))).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(books);


        }
        //END OF BokkService Logics
        public void Dispose()
        {
            Database.Dispose();
        }
        //Start of CategoryService Logics
        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }
    }
}
