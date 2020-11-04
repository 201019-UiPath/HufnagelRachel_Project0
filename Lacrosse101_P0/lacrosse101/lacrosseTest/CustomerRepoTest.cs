using System.Collections.Generic;
using System.Linq;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace lacrosseTest
{
    public class CustomerRepoTest
    {

        [Fact]
        public void GetAllCustomerShouldGetAllCustomers() 
        {
           using var tester = new lacrosseContext();
           ICustomerRepo custRepo = new DBRepo(tester);
           List<Customer> custResult = custRepo.GetAllCustomers();
           Assert.NotNull(custResult);
        }

        [Fact]
        public void AddCustomerShouldAddCustomer() 
        {
            using var tester = new lacrosseContext();
            ICustomerRepo custRepo = new DBRepo(tester);
            Customer newCust = new Customer();
            newCust.FirstName = "NewCustFirst";
            newCust.LastName = "NewCustLast";
            newCust.LocationId = 2;
            newCust.CustAddress = "Arizona";
            
            custRepo.AddCustomer(newCust); 
            Assert.NotNull(tester.Customer.Single(c => c.FirstName == newCust.FirstName && c.LastName == newCust.LastName));
            custRepo.DeleteACustomer(newCust);
        }

        public void UpdateCustomerShouldUpdateCustomer
    }
}
 