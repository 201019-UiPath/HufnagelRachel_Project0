using System.Collections.Generic;
using System.Threading.Tasks;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using System.Text.Json;
using System;
using System.IO;

namespace lacrosseDB
{
    public class IFileRepo : ICustomerRepo
    {
        public string filepath = "lacrosseDB/DBFiles/Customer.txt";
        public async void AddCustomer(Customer customer)
        {
            using (FileStream fs = File.Create(path: filepath)){
                await JsonSerializer.SerializeAsync(fs, customer);
                System.Console.WriteLine("Customer being written to Customer.txt file");
            }
        }

        public async void DeleteACustomer(Customer customer)
        {
            List<Customer> cust2Delete = new List<Customer>(1);
            cust2Delete.Add(customer);
            using (FileStream fs = File.OpenRead(path: filepath)) 
            {
                cust2Delete.Remove(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
        }

        public async List<Customer> GetAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>();
            using (FileStream fs = File.OpenRead(path: filepath)) 
            {
                allCustomers.Add(await JsonSerializer.DeserializeAsync<Customer>(fs));
            }
        }

        public Customer GetCustomerByCustId(int custId)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerByName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdateCutomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}