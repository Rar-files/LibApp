using System.Collections.Generic;
using LibApp.Models;

namespace LibApp.Interfaces
{
    public interface ICustomerActions
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        void Delete(int id);
        void Add(Customer customer);
        void Update(Customer customer);
    }
}