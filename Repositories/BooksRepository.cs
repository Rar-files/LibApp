using System.Collections.Generic;
using LibApp.Models;
using LibApp.Data;
using LibApp.Interfaces;

namespace LibApp.Respositories
{
    public class BookRepository : IBookActions
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetBooks() => _context.Books;
        public Book GetBookById(int id) => _context.Books.Find(id);
        public void Add(Book book)=> _context.Books.Add(book);
        public void Delete(int id) => _context.Books.Remove(GetBookById(id));
        public void Update(Book book) => _context.Books.Update(book);
        public void Save() => _context.SaveChanges();
    }
}
