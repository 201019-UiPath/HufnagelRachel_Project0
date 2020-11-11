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
        private ILineItemRepo lineItemRepo;
        private lineItemServices lineItemServices;

        public CheckoutMenu(Customer customer, lacrosseContext context, ICustomerRepo customerRepo, ILocationRepo locationRepo, IInventoryRepo inventoryRepo, IProductRepo productRepo, ICartRepo cartRepo, ICartItemsRepo cartItemsRepo, IOrderRepo orderRepo, ILineItemRepo lineItemRepo)
        {
            this.customer = customer;
            this.customerRepo = customerRepo;
            this.inventoryRepo = inventoryRepo;
            this.locationRepo = locationRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
            this.cartRepo = cartRepo;
            this.cartItemsRepo = cartItemsRepo;
            this.lineItemRepo = lineItemRepo;
            this.customerServices = new CustomerServices(customerRepo);
            this.locationServices = new LocationServices(locationRepo);
            this.inventoryServices = new InventoryServices(inventoryRepo);
            this.productServices = new ProductServices(productRepo);
            this.cartServices = new CartServices(cartRepo);
            this.cartItemServices = new CartItemServices(cartItemsRepo);
            this.orderServices = new OrderServices(orderRepo);
            this.lineItemServices = new lineItemServices(lineItemRepo);
        }

        public void Start()
        {
            do
            {
                Cart cart = cartServices.GetCartByCustId(customer.Id);
                List<CartItem> ci = cartItemServices.GetAllCartItemsByCartId(cart.Id);
                Console.WriteLine("These are the items in your cart");
                foreach(CartItem item in ci)
                {
                    Sticks stick = productServices.GetProductByStickId(item.stickId);
                    Console.WriteLine($"{stick.description} \t${stick.Price}");
                }
                Console.WriteLine("Welcome to check out! If there is anything you forget go back otherwise proceed to checkout. Thank you for Shopping with us.");
                Console.WriteLine("[0] Back \n[2] Checkout");
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
            double total = 0;
            order.CustomersId = customer.Id;
            order.LocationId = customer.LocationId;
            DateTime dateOfOrder = order.dateOfOrder = DateTime.Now;
            orderServices.AddOrder(order);
            Orders orderToProcess = orderServices.GetOrderByDate(dateOfOrder);
            Console.WriteLine("You imaginary order has been placed. You will revieve it never. \n");
            foreach(CartItem item in items)
            {
                lineItem lineItem = new lineItem();
                Sticks stick = productServices.GetProductByStickId(item.stickId);
                lineItem.orderId = orderToProcess.Id;
                lineItem.stickId = item.stickId;
                lineItem.price = stick.Price;
                lineItem.quantity = item.quantity;
                total += (stick.Price * item.quantity);
                lineItemServices.AddLineItem(lineItem);
                cartItemServices.DeleteCartItem(item);
                Inventory inventory = inventoryServices.GetItemByLocIdStickId(customer.LocationId, stick.Id);
                inventory.quantity -= item.quantity;

            }
            order.TotalPrice = total;
            orderServices.UpdateOrder(orderToProcess);
            Console.WriteLine($"\nYour total was: ${order.TotalPrice}");
        }
    }
}