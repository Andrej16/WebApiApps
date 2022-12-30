using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiApps.Models;

namespace WebApiApps.Services
{
    public class BookService
    {
        private readonly WebApiAppsContext _context;

        public BookService(IDatabaseSettings settings)
        {
            var contextOptions = new DbContextOptionsBuilder<WebApiAppsContext>()
                .UseSqlServer(settings.ConnectionString).Options;

            _context = new WebApiAppsContext(contextOptions);
        }

        public List<Book> Get() => _context.Books.ToList();

        public Book Get(string id) => _context.Books.Find(id);

        public Book Create(Book book)
        {
            _context.Books.Add(book);

            _context.SaveChanges();

            return book;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);

            _context.SaveChanges();
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);

            _context.SaveChanges();
        }
    }
}
