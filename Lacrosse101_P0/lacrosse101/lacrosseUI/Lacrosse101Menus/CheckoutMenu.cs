using System;
using System.Collections.Generic;
using lacrosseDB;
using lacrosseDB.Models;
using lacrosseDB.Repos;
using lacrosseLib;

namespace lacrosseUI.Lacrosse101Menus
{
    public class CheckoutMenu : IMenu
    {
        private string custInput;
        private Customer customer;
        private ICustomerRepo customerRepo;
        private CustomerServices customerServices;
        private ILocationRepo locationRepo;
        private LocationServices locationServices;
        private IInventoryRepo inventoryRepo;
        private InventoryServices inventoryServices;
        private IProductRepo productRepo;
        private ProductServices productServices;
        private ICartRepo cartRepo;
        private CartServices cartServices;
        private ICartItemsRepo cartItemsRepo;
        private CartItemServices cartItemServices;
        private IOrderRepo orderRepo;
        private OrderServices orderServices;

        public CheckoutMenu(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, ILocationRepo locationRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, ICartRepo cartRepo, ICartItemsRepo cartItemsRepo, IOrderRepo orderRepo)
        {
            this.customer = customer;
            this.customerRepo = customerRepo;
            this.inventoryRepo = inventoryRepo;
            this.locationRepo = locationRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.cartRepo = cartRepo;
            this.cartItemsRepo = cartItemsRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.locationServices = new LocationServices(locationRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.cartServices = new CartServices(cartRepo);
            this.cartItemServices = new CartItemServices(cartItemsRepo);
            this.orderServices = new OrderServices(orderRepo);
        }

        public void Start()
        {
            do
            {
                Console.WriteLine("Welcome to check out! If there is anything you forget go back otherwise proceed to checkout. Thank you for Shopping with us.");
                Console.WriteLine("[0] Back \n[2]Checkout");
                custInput = Console.ReadLine();
                switch(custInput)
                {
                    case "0":
                        break;

                    case "2":
                        CheckOutItems();
                        break;

                    default:
                        ValidInvalidServices.InvalidInput();
                        break;
                }

            } while (!(custInput.Equals("0")));
        }

        public void CheckOutItems()
        {
            Cart cart = cartServices.GetCartByCustId(customer.Id);
            List<CartItem> items = cartItemServices.GetAllCartItemsByCartId(cart.Id);
            Orders order = new Orders();
            float totalPriceSticks = 0.0F;
            float totalPriceBalls = 0.0F;
            order.CustomersId = customer.Id;
            order.LocationId = customer.LocationId;
            DateTime dateOfOrder = order.dateOfOrder = DateTime.Now;
            orderServices.AddOrder(order);
            Orders orderToProcess = orderServices.GetOrderByDate(dateOfOrder);
            Console.WriteLine("You imaginary order has been placed. You will revieve it never");
            foreach(CartItem item in items)
            {
                Balls ball = productServices.GetBallByBallId(item.ballId);
                totalPriceSticks += (ball.Price * item.quantity);
                Sticks stick = productServices.GetStickByStickId(item.stickId);
                totalPriceSticks += (stick.Price * item.quantity);
            }
            order.TotalPrice = (totalPriceBalls+totalPriceSticks);
            orderServices.UpdateOrder(orderToProcess);
            Console.WriteLine($"Your total was: {order.TotalPrice}");
        }
    }
}