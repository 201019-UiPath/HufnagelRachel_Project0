using System.Collections.Generic;
using System.Threading.Tasks;
using lacrosseDB.Models;

namespace lacrosseDB.FileRepos
{
    public interface ICustomerRepo_2
    {
         Task<List<Customer>> GetAllCustomersAsync();
         void AddACustomerAsync(Customer customer);
    }
}