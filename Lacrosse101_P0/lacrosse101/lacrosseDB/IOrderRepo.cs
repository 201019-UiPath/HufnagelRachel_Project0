using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB
{
    public interface IOrderRepo
    {
         List<Orders> GetCustomerOrderHistory(int Id);
    }
}