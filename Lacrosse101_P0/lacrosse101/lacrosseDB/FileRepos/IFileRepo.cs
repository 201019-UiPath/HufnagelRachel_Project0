using System.Collections.Generic;
using System.Threading.Tasks;
using lacrosseDB.Models;
using System.Text.Json;
using System;
using System.IO;

namespace lacrosseDB.FileRepos
{
    public class IFileRepo : ICustomerRepo_2
    {
        public string filepath = "lacrosseDB/DBFiles/Customer.txt";

        public async void AddACustomerAsync(Customer customer)
        {
            using (FileStream fs = File.Create(path: filepath)){
                await JsonSerializer.SerializeAsync(fs, customer);
                System.Console.WriteLine("Customer being written to Customer.txt file");
            }
        }

        // public async void DeleteACustomer(Customer customer)
        // {
        //     List<Customer> cust2Delete = new List<Customer>(1);
        //     cust2Delete.Add(customer);
        //     using (FileStream fs = File.OpenRead(path: filepath)) 
        //     {
        //         cust2Delete.Remove(await JsonSerializer.DeserializeAsync<Customer>(fs));
        //     }
        // }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            List<Customer> allCustomers = new List<Customer>();
            using (FileStream fs = File.OpenRead(path: filepath)) 
            {
                allCustomers.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
            return allCustomers;
        }
    }
}