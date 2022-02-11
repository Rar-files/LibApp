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
        public IEnumerable<Rental> GetRentals() => _context.Rentals;
        public Rental GetRentalById(int id) => _context.Rentals.Find(id);
        public void Add(Rental rental)=> _context.Rentals.Add(rental);
        public void Delete(int id)=> _context.Rentals.Remove(GetRentalById(id));
        public void Update(Rental rental) => _context.Rentals.Update(rental);
        public void Save() => _context.SaveChanges();

        //AsyncedMethods
        public async Task<IEnumerable<Rental>> GetRentalsAsync() => await _context.Rentals.ToListAsync();
        public async Task<Rental> GetRentalByIdAsync(int id) => await _context.Rentals.FindAsync(id);
        public async Task DeleteAsync(int id)
        {
            _context.Rentals.Remove(GetRentalById(id));
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