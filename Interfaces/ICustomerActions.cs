using System.Collections.Generic;
using LibApp.Models;
using System.Threading.Tasks;

namespace LibApp.Interfaces
{
    public interface ICustomerActions
    {
        //Methods
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        void Delete(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Save();

        //AsyncedMethods
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task SaveAsync();
    }
}