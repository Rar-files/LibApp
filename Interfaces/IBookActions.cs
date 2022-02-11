using LibApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    //Methods
    public interface IBookActions
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        void Delete(int id);
        void Add(Book book);
        void Update(Book book);
        void Save();

        //AsyncedMethods
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task SaveAsync();
    }   
}
