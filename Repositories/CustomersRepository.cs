using LibApp.Models;
using LibApp.Data;
using LibApp.Interfaces;
using System.Collections.Generic;

namespace LibApp.Respositories
{
    public class CustomerRepository : ICustomerActions
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers() => _context.Customers;
        public Customer GetCustomerById(int id) => _context.Customers.Find(id);
        public void Add(Customer customer) => _context.Customers.Add(customer);
        public void Delete(int id) => _context.Customers.Remove(GetCustomerById(id));
        public void Update(Customer customer) => _context.Customers.Update(customer);
        public void Save() => _context.SaveChanges();
    }
}