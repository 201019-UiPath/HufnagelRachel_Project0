using System.Collections.Generic;
using System.Threading.Tasks;
using lacrosseDB.Models;
using System.Text.Json;
using System;
using System.IO;

namespace lacrosseDB
{
    public class IFileRepo : ICustomerRepo
    {
        public string filepath = "lacrosseDB/DBFiles/Customer.txt";
        public async void AddCustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(filepath)) {
                await JsonSerializer.SerializeAsync(fs, customer);
                System.Console.WriteLine("Customer is being written to file...");
            }
        }

        public Task<List<Customer>> GetAllCustomersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCutomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}