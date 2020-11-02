using System.Collections.Generic;
using lacrosseDB.Models;

namespace lacrosseDB.Repos
{
    public interface IOrderRepo
    {
        void AddOrder (Orders order);
        void UpdateOrders(Orders order);
        Orders GetOrderByOrderId(int orderId);
        Orders GetOrderByCustId(int custId);
        Orders GetOrderByLocationId (int locationId);
        List<Orders> GetAllOrdersByCustId(int custId);
        List<Orders> GetAllOrdersByLocationId (int locationId);
        void DeleteAOrder(Orders order);
    }
}