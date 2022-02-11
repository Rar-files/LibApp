using System.Collections.Generic;
using LibApp.Models;
using System.Threading.Tasks;

namespace LibApp.Interfaces
 {
    public interface IGenreActions
    {
        //Methods
        IEnumerable<Genre> GetGenres();
        Genre GetGenreById(int id);
        void Delete(int id);
        void Add(Genre genre);
        void Update(Genre genre);
        void Save();

        //AsyncedMethods
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task SaveAsync();
    }
 }