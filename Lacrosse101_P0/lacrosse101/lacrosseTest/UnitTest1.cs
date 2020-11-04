using System.Collections.Generic;
using System.Linq;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace lacrosseTest
{
    public class UnitTest1
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
            newCust.email = "newCust@gmail.com";
            newCust.LocationId = 2;
            newCust.CustAddress = "Arizona";
            
            custRepo.AddCustomer(newCust); 
            Assert.NotNull(tester.Customer.Single(c => c.FirstName == newCust.FirstName && c.LastName == newCust.LastName));
            custRepo.DeleteACustomer(newCust);
        }

        // [Fact]
        // public void UpdateCustomerShouldUpdateCustomer() 
        // {
        //     using var tester = new lacrosseContext();
        //     ICustomerRepo custRepo = new DBRepo(tester);
        //     Customer newCust = new Customer();
        //     newCust.FirstName = "NewCustFirst";
        //     newCust.LastName = "NewCustLast";
        //     newCust.email = "rachel@revature.net";
        //     custRepo.AddCustomer(newCust);

        //     newCust.email = "rachel.hufnagel@revature.net";
        //     custRepo.UpdateCustomer(newCust);
        //     var RS = custRepo.GetCustomerByEmail(newCust.email);
        //     Assert.Equal("rachel.hufnagel@revature.net", RS.email);
        //     custRepo.DeleteACustomer(newCust);
        // }

        // [Fact]
        // public void AddBallShouldAdd()
        // {
        //     using var TContext = new lacrosseContext();
        //     IProductRepo repo = new DBRepo(TContext);
        //     Balls testerBall = new Balls();
        //     testerBall.colorType = Balls.ColorType.Yellow;
        //     testerBall.Price = 4.50F;
        //     testerBall.locationId = 1;
        //     repo.AddBall(testerBall);
        //     Assert.NotNull(TContext.Balls.Single(b => b.locationId == testerBall.locationId));
        //     repo.DeleteBall(testerBall);
        // }
    }
}



 
