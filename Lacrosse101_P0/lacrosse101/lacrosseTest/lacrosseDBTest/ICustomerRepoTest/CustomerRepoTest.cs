using System;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using Xunit;

namespace ICustomerRepoTest
{
    public class CustomerRepoTest
    {
        [Fact]
        public void UpdateUserShouldUpdate() 
        {
           using var tester = new lacrosseContext();
          // tester.CustAddress = "Test.Name";
        }
    }
}
