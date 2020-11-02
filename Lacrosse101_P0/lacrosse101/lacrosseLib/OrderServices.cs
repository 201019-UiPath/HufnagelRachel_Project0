using lacrosseDB;
using lacrosseDB.Repos;
using lacrosseDB.Models;
using System.Collections.Generic;

namespace lacrosseLib
{
    public class OrderServices
    {
        private IOrderRepo orderRepo;

        public OrderServices(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        public void AddOrder(Order order)
        {
            orderRepo.AddOrder(order);
        }


        public void UpdateOrder(Orders order)
        {
            orderRepo.UpdateOrder(order);
        }

        public Orders GetOrderByOrderId(int orderId)
        {
            Order order = orderRepo.GetOrderByOrderId(orderId);
            return order;
        }

        public Orders GetOrderByCustId(int custId)
        {
            Orders order = orderRepo.GetOrderByCustId(custId);
            return order;
        }

        public Orders GetOrderByLocationId(int locationId)
        {
            Orders order = orderRepo.GetOrderByLocationId(locationId);
            return order;
        }

        public List<Orders> GetAllOrdersByCustId(int custId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByCustId(custId);
            return orders;
        }

        public List<Orders> GetAllOrdersByLocationId(int locationId)
        {
            List<Orders> orders = orderRepo.GetAllOrdersByLocationId(locationId);
            return orders;
        }

        public void DeleteOrder(Orders order) {
            orderRepo.DeleteOrder(order);
        }

        // need to add the methods for sorted order lists from P0 requirements


    }
}