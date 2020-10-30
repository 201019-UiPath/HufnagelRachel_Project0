using System.Collections.Generic;
using lacrosseDB.Models;
using System.Threading.Tasks;

namespace lacrosseDB
{
    public interface ICustomerRepo 
    {
        void AddCustomerAsync (Customer customer);
        void RemoveCutomer (Customer customer);

        Task<List<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerByEmail(string email);
    }
}
