using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class OrderHistoryMenu : IMenu
    {
        private string custInput;
        private Customer customer;
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryService;
        private IProductRepo productRepo;
        private ProductServices productServices;
        private IOrderRepo orderRepo;
        private OrderServices orderService;
        private ILocationRepo locationRepo;
        private LocationServices locationService;

        public OrderHistoryMenu(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, IOrderRepo orderRepo, ILocationRepo locationRepo)
        {
            this.customer = customer;
            this.customerRepo = customerRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.inventoryRepo = inventoryRepo;
            this.locationRepo = locationRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.locationService = new LocationServices(locationRepo);
            this.productServices = new ProductServices(productRepo);
            this.orderService = new OrderServices(orderRepo);
            this.inventoryService = new InventoryServices(inventoryRepo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("Welcome to your order history, please select one of the options below: ");
                Console.WriteLine("[0] Go back \n[1] Sort By Date Asc \n[2] Sort By Date Desc \n[3] Sort By Price Asc \n[4] Sort By Price Desc");

                custInput = Console.ReadLine();
                switch (custInput)
                {
                    case "0":
                        break;
                    case "1":
                        GetOrdersByDateAsc();
                        break;
                    case "2":
                        GetOrdersByDateDesc();
                        break;
                    case "3":
                        GetOrdersByPriceAsc();
                        break;
                    case "4":
                        GetOrdersByPriceDesc();
                        break;
                    default:
                        ValidInvalidServices.InvalidInput();
                        break;

                }
            } while (!(custInput.Equals("0")));
        }


        public void GetOrdersByDateAsc()
        {
            Console.WriteLine("Your orders by Date in ascending order");
            List<Orders> custOrders = orderService.GetAllOrdersByCustIdDateAsc(customer.Id);
            foreach(Orders order in custOrders) 
            {
                Locations location = locationService.GetLocationByLocationId(order.LocationId);
                Console.WriteLine($"Date of Order: {order.dateOfOrder} \tTotal: ${order.TotalPrice} \tStore Number: {order.LocationId} \n");
            }
        }

        public void GetOrdersByDateDesc()
        {
            Console.WriteLine("Your orders by Date in desending order");
            List<Orders> custOrders = orderService.GettAllOrdersByCustIdDateDesc(customer.Id);
            foreach(Orders order in custOrders) 
            {
                Locations location = locationService.GetLocationByLocationId(order.LocationId);
                Console.WriteLine($"Date of Order: {order.dateOfOrder} \tTotal: ${order.TotalPrice} \tStore Number: {order.LocationId} \n");
            }
        }

        public void GetOrdersByPriceAsc()
        {
            Console.WriteLine("Your orders by Price in ascending order");
            List<Orders> custOrders = orderService.GetAllOrdersByCustIdPriceAsc(customer.Id);
            foreach(Orders order in custOrders) 
            {
                Locations location = locationService.GetLocationByLocationId(order.LocationId);
                Console.WriteLine($"Date of Order: {order.dateOfOrder} \tTotal: ${order.TotalPrice} \tStore Number: {order.LocationId} \n");
            }
        }

        public void GetOrdersByPriceDesc() 
        {
            Console.WriteLine("Your orders by Price in desending order");
            List<Orders> custOrders = orderService.GetAllOrdersByCustIdPriceDesc(customer.Id);
            foreach(Orders order in custOrders) 
            {
                Locations location = locationService.GetLocationByLocationId(order.LocationId);
                Console.WriteLine($"Date of Order: {order.dateOfOrder} \tTotal: ${order.TotalPrice} \tStore Number: {order.LocationId} \n");
            }
        }
    }
}