using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using LibApp.Models;
using LibApp.Data;
using LibApp.Interfaces;

namespace LibApp.Respositories
{
    public class GenreRepository : IGenreActions
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Genre> GetGenres() => _context.Genre;
        public Genre GetGenreById(int id) => _context.Genre.Find(id);
        public void Add(Genre genre)=> _context.Genre.Add(genre);
        public void Delete(int id)=> _context.Genre.Remove(GetGenreById(id));
        public void Update(Genre genre) => _context.Genre.Update(genre);
        public void Save() => _context.SaveChanges();

        public async Task<IEnumerable<Genre>> GetGenresAsync() => await _context.Genre.ToListAsync();
        public async Task<Genre> GetGenreByIdAsync(int id) => await _context.Genre.FindAsync(id);
        public async Task DeleteAsync(int id)
        {
            _context.Genre.Remove(GetGenreById(id));
            await SaveAsync();
        }

        public async Task AddAsync(Genre genre) => await _context.Genre.AddAsync(genre);
        public async Task UpdateAsync(Genre genre)
        {
            _context.Genre.Update(genre);
            await SaveAsync();
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}