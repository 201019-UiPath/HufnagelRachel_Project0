using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface ICustomerRepo 
    {
        void AddCustomer (Customer customer);
        void UpdateCustomer (Customer customer);
        Customer GetCustomerByCustId (int custId);
        Customer GetCustomerByName (string firstName, string lastName);
        List <Customer> GetAllCustomers();
        void DeleteACustomer (Customer customer);

    }
}
