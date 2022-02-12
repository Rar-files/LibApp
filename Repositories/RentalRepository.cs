using System.Collections.Generic;
using LibApp.Models;
using LibApp.Data;
using LibApp.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Respositories
{
    public class RentalRepository : IRentalActions
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Methods
        public IEnumerable<Rental> Get() => _context.Rentals;
        public Rental GetById(int id) => _context.Rentals.Find(id);
        public void Add(Rental rental)=> _context.Rentals.Add(rental);
        public void Delete(int id)=> _context.Rentals.Remove(GetById(id));
        public void Update(Rental rental) => _context.Rentals.Update(rental);
        public void Save() => _context.SaveChanges();

        //AsyncedMethods
        public async Task<IEnumerable<Rental>> GetAsync() => await _context.Rentals.ToListAsync();
        public async Task<Rental> GetByIdAsync(int id) => await _context.Rentals.FindAsync(id);
        public async Task DeleteAsync(int id)
        {
            _context.Rentals.Remove(GetById(id));
            await SaveAsync();
        }

        public async Task AddAsync(Rental rental) => await _context.Rentals.AddAsync(rental);
        public async Task UpdateAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await SaveAsync();
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}